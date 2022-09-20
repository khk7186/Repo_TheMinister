using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Playables;

public class LightController : MonoBehaviour, IObserver
{
    public GameObject Day;
    public GameObject Evening;
    public GameObject Night;

    public GameObject Day_Evening;
    public GameObject Evening_Night;
    public GameObject Night_Day;

    public int speedMulti = 2;

    public Map map;
    private void Awake()
    {
        foreach (var subject in FindObjectsOfType<MonoBehaviour>().OfType<ISubject>())
        {
            subject.RegisterObserver(this);
        }
        map = FindObjectOfType<Map>(true);
        if (map.Day == 0)
        {
            ChangeLight(0);
        }
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        ChangeLight(map.DayTime);
    }
    public void ChangeLight(int DayTime)
    {

        switch (DayTime)
        {
            case 0:
                Day_Evening.gameObject.SetActive(false);
                Evening_Night.gameObject.SetActive(false);
                Night.gameObject.SetActive(false);
                Night_Day.gameObject.SetActive(true);
                break;
            case 1:
                Night_Day.gameObject.SetActive(false);
                Evening_Night.gameObject.SetActive(false);
                Day.gameObject.SetActive(false);
                Day_Evening.gameObject.SetActive(true);
                break;
            case 2:
                Night_Day.gameObject.SetActive(false); 
                Day_Evening.gameObject.SetActive(false);
                Evening.gameObject.SetActive(false);
                Evening_Night.gameObject.SetActive(true);
                break;
        }
    }
}
