using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleChangeSideTrigger : MonoBehaviour
{
    [SerializeField] private bool front;
    [SerializeField] private bool right;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(2);
        if (collision.gameObject.TryGetComponent<SideChanger>(out var changer))
        {
            changer.changeSide(front, right);
        }
    }
}
