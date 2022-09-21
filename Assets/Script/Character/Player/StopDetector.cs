using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDetector : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public float distanceToDetect = 2048 * 2048f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IStopPlayer target))
        {
            Debug.Log("stop");
            GameObject ai = target.gameObject;
            float distanceToTarget = (ai.transform.position.x - transform.position.x) * (ai.transform.position.x - transform.position.x)
                + (ai.transform.position.y - transform.position.y) * (ai.transform.position.y - transform.position.y);
            if (distanceToTarget < distanceToDetect)
            {
                distanceToDetect = distanceToTarget;
                characterMovement.finalBlock = (target.CurrentBlock - 1)% MovementGrid.PlayerMovementBlocks.Count;
            }
        }
    }
}
