using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Combat : MonoBehaviour
{
    public Queue CombatQueue = new Queue();
    public static Combat NewCombat()
    {
        if (FindObjectOfType<CombatSceneController>().OnAction)
        {
            return null;
        }
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
                if (FindObjectOfType<CombatSceneController>().fastMode)
                {
                    Time.timeScale = 3f;
                }
                yield return OnActionCCU.GetComponent<StartFight>().StartNewFight();
            }
            else
                yield return null;
            Time.timeScale = 1f;
        }
        foreach (var ccu in FindObjectsOfType<CombatCharacterUnit>())
        {
            ccu.Defender = null;
        }
        yield return new WaitForEndOfFrame();
        CombatInteractableUnit.SetActiveAllLine(true);
        FindObjectOfType<CombatUI>().BlackFrameAnimation(true);
        ReprocessLineRenderIfTargetOff();
        if (CombatTutorManager.TutorialLevelIsOn)
        {
            FindObjectOfType<CombatTutorManager>().RountIndex += 1;
        }
        Destroy(gameObject);
    }
    public void ReprocessLineRenderIfTargetOff()
    {
        var interactables = FindObjectsOfType<CombatInteractableUnit>();
        foreach (var interactable in interactables)
        {
            var ccu = interactable.GetComponent<CombatCharacterUnit>();
            if (ccu.target == null || ccu.target.gameObject.activeSelf == false)
            {
                Destroy(interactable.line.gameObject);
                ccu.target = null;
                ccu.currentAction = CombatAction.NoSelect;
            }
        }
    }

}
