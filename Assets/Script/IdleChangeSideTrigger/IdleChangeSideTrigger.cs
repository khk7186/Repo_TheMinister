using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IdleChangeSideTrigger : MonoBehaviour, IObserver
{
    [SerializeField] private bool front;
    [SerializeField] private bool right;

    private bool adjusted = true;

    private void Awake()
    {
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.DiceRoll)
        {
            adjusted = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<SideChanger>(out var changer))
        {
            changer.changeSide(front, right);
            adjusted = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (adjusted == true) return;
        if (collision.gameObject.TryGetComponent<SideChanger>(out var changer))
        {
            changer.changeSide(front, right);
            adjusted = true;
        }
    }
}
