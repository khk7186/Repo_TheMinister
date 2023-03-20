using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayToSpawn : MonoBehaviour
{
    public bool startCountOnEnable;
    public int delayRounds = 1;
    public List<GameObject> gameObjects;

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
        int start = player.currentBlock;
        for (int i = 0; i < delayRounds; i++)
        {
            yield return new WaitUntil(() => player.currentBlock == start - 1);
        }
        foreach (var item in gameObjects)
        {
            Instantiate(item);
            item.transform.position = Vector3.zero;
        }
        Destroy(gameObject);
    }
}
