using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerFirstMove : MonoBehaviour, IDiceRollEvent
{
    public List<GameObject> _objectsToActive;
    public List<GameObject> _objectsToInactive;
    public Dice dice;
    public void OnNotify(object value, NotificationType notificationType)
    {
        Debug.Log("Notify");
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
        var map = FindObjectOfType<Map>(true);
        map.GameStart = true;
        map?.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        dice.RegisterObserver(this);
    }
}
