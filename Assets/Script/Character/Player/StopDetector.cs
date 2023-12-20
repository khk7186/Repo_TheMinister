using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDetector : MonoBehaviour
{
    public CharacterMovement characterMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IStopPlayer target))
        {
            Debug.Log("stop");
            GameObject ai = target.gameObject;
            if (ai.GetComponent<ForceAction>().stopPlayer == false) return;
            float distanceToTarget = (ai.transform.position.x - transform.position.x) * (ai.transform.position.x - transform.position.x)
                + (ai.transform.position.y - transform.position.y) * (ai.transform.position.y - transform.position.y);
            characterMovement.finalBlock = (target.CurrentBlock - 1) % MovementGrid.PlayerMovementBlocks.Count;
            FindObjectOfType<Map>().OnStory = true;
        }
    }
}
