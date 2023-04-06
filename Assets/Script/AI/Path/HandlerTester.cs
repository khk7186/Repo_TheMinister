using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class HandlerTester : MonoBehaviour,IDiceRollEvent
{
    public PathPoint current;
    public void OnEnable()
    {
        foreach (var subject in GameObject.FindObjectsOfType<MonoBehaviour>().OfType<IDiceSubject>())
        {
            subject.RegisterObserver(this);
        }
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        run();
    }

    public void run()
    {
        var handler = new PathPointHandler(current);
        handler.PlanPath();
        StartCoroutine(WaitUntilRespond(handler));
    }
    public IEnumerator WaitUntilRespond(PathPointHandler handler)
    {
        yield return new WaitUntil(()=>handler.Ready == true);
        current = handler.targetPoint;
        Debug.Log("Deployee at" + current.name);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
