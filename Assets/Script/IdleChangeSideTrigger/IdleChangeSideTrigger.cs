using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IdleChangeSideTrigger : MonoBehaviour,IObserver
{
    [SerializeField] private bool front;
    [SerializeField] private bool right;
    private List<SideChanger> sideChangers = new List<SideChanger>();

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
            foreach (var sideChanger in sideChangers)
            {
                sideChanger.changeSide(front, right);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var changer = collision.gameObject.GetComponent<SideChanger>();
        ChangeSide(changer);
        sideChangers.Add(changer);
        //Debug.Log($"front={front};right = {right}");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sideChangers.Remove(collision.gameObject.GetComponent<SideChanger>());
    }
    private void ChangeSide(SideChanger sideChanger)
    {
        if (sideChanger != null)
        {
            sideChanger.changeSide(front, right);
        }
    }
}
