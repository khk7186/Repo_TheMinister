using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    public GameObject cutScenePref;

    private void Spawn()
    {
        Instantiate(cutScenePref);
    }
    private void PreparePlayer()
    {
        var player = FindObjectOfType<Player>();
        var playerCM = player.GetComponent<CharacterMovement>();
        playerCM.StopCoroutine(playerCM.MoveToLocation());
        playerCM.finalBlock = playerCM.currentBlock;
        player.GetComponent<Animator>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PreparePlayer();
        Spawn();
    }
}
