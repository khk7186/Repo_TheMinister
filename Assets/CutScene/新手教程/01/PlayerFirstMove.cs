using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerFirstMove : MonoBehaviour, IObserver
{
    public List<GameObject> _objectsToActive; 
    
    public void OnNotify(object value, NotificationType notificationType)
    {
        foreach (var obj in _objectsToActive)
        {
            Debug.Log("OnNotify");
            obj.SetActive(true);
        }
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.CancelObserver(this);
        }
        FindObjectOfType<Map>(true)?.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        foreach (var subject in FindObjectsOfType<MonoBehaviour>(true).OfType<ISubject>())
        {
            Debug.Log("RegisterObserver");
            subject.RegisterObserver(this);
        }
    }
}
