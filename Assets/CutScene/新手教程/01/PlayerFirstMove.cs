using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerFirstMove : MonoBehaviour, IObserver
{
    public List<GameObject> _objectsToActive; 
    public List<GameObject> _objectsToInactive;
    public void OnNotify(object value, NotificationType notificationType)
    {
        foreach (var obj in _objectsToActive)
        {
            obj.SetActive(true);
        }
        foreach (var obj in _objectsToInactive)
        {
            obj.SetActive(false);
        }
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.CancelObserver(this);
        }
        //var map = FindObjectOfType<Map>(true);
        //map.GameStart = true;
        //map?.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        foreach (var subject in FindObjectsOfType<MonoBehaviour>(true).OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
    }
}
