using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerFirstMove : MonoBehaviour, IDiceRollEvent
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
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<IDiceSubject>())
        {
            subject.CancelObserver(this);
        }
        //var map = FindObjectOfType<Map>(true);
        //map.GameStart = true;
        //map?.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        foreach (var subject in FindObjectsOfType<MonoBehaviour>(true).OfType<IDiceSubject>())
        {
            subject.RegisterObserver(this);
        }
    }
}
