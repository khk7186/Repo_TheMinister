using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayToSpawn : MonoBehaviour
{
    public bool startCountOnEnable;
    public int delayRounds = 1;
    public List<GameObject> gameObjects;
    public bool UsePlanedBlock = false;
    public int PlanedBlock = 0;

    private void OnEnable()
    {
        transform.parent = null;
        if (startCountOnEnable)
        {
            StartCoroutine(WaitToSpawn());
        }
    }
    

    public IEnumerator WaitToSpawn()
    {
        var player = FindObjectOfType<Player>().GetComponent<CharacterMovement>();
        int start = PlanedBlock;
        for (int i = 0; i < delayRounds; i++)
        {
            yield return new WaitUntil(() => player.currentBlock == PlanedBlock);
        }
        foreach (var item in gameObjects)
        {
            Instantiate(item);
            item.transform.position = Vector3.zero;
        }
        Destroy(gameObject);
    }
}
