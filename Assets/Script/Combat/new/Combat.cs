using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Combat : MonoBehaviour
{
    public Queue CombatQueue = new Queue();
    //private static void Start()
    //{
    //    var combat = new Combat();
        
    //}
    public static Combat NewCombat()
    {
        if (FindObjectOfType<Combat>() != null)
        {
            return null;
        }
        var combat = new GameObject().gameObject.AddComponent<Combat>();
        var allCCUinGame = GameObject.FindObjectsOfType<CombatCharacterUnit>().ToList();
        combat.MakeQueue(allCCUinGame);
        combat.StartCoroutine(combat.StartCombat());
        return new Combat();
    }
    public void MakeQueue(List<CombatCharacterUnit> ccus)
    {
        List<CombatCharacterUnit> readyToQue = ccus;
        readyToQue.Sort(new CCUComparer());
        for (int i = 0; i < ccus.Count; i++)
        {
            CombatQueue.Enqueue(readyToQue[i]);
        }
    }
    public IEnumerator StartCombat()
    {
        FindObjectOfType<CombatUI>().BlackFrameAnimation(false);
        while (CombatQueue.Count > 0)
        {
            var OnActionCCU = (CombatCharacterUnit)CombatQueue.Dequeue();
            if (OnActionCCU != null)
            {
                yield return OnActionCCU.GetComponent<StartFight>().StartNewFight();
            }
            else
                yield return null;
        }
        yield return new WaitForEndOfFrame();
        CombatInteractableUnit.SetActiveAllLine(true);
        FindObjectOfType<CombatUI>().BlackFrameAnimation(true);
        Destroy(gameObject);
    }


}
