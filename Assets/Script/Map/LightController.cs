using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour, IDiceRollEvent
{
    public GameObject Day;
    public GameObject Evening;
    public GameObject Night;

    public GameObject Day_Evening;
    public GameObject Evening_Night;
    public GameObject Night_Day;

    public GameObject Wrapper;

    public int speedMulti = 2;
    public static LightController Instance;

    public Map map;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Dice.Instance.CancelObserver(this);
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        map = Map.Instance;
        if (map.Day == 0)
        {
            ChangeLight(0);
        }
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }
    private void OnEnable()
    {
        if (map != null)
            ChangeLight(map.DayTime);
        if (Instance != this) { Instance = this; }
        else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
        if (Dice.Instance != null)
        {
            Dice.Instance.RegisterObserver(this);
        }
    }
    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        if (arg1.buildIndex != 1)
        {
            Wrapper.SetActive(false);
        }
        else
        {
            Wrapper.SetActive(true);
            ConstantLight(map.DayTime);
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
                Day.gameObject.SetActive(false);
                Night.gameObject.SetActive(false);
                Evening.gameObject.SetActive(false);
                Night_Day.gameObject.SetActive(true);
                break;
            case 1:
                Night_Day.gameObject.SetActive(false);
                Evening_Night.gameObject.SetActive(false);
                Day.gameObject.SetActive(false);
                Night.gameObject.SetActive(false);
                Evening.gameObject.SetActive(false);
                Day_Evening.gameObject.SetActive(true);
                break;
            case 2:
                Night_Day.gameObject.SetActive(false);
                Day_Evening.gameObject.SetActive(false);
                Day.gameObject.SetActive(false);
                Night.gameObject.SetActive(false);
                Evening.gameObject.SetActive(false);
                Evening_Night.gameObject.SetActive(true);
                break;
        }
    }

    public void ConstantLight(int DayTime)
    {
        switch (DayTime)
        {
            case 0:
                Day_Evening.gameObject.SetActive(true);
                Evening_Night.gameObject.SetActive(false);
                Night.gameObject.SetActive(false);
                break;
            case 1:
                Night_Day.gameObject.SetActive(false);
                Evening_Night.gameObject.SetActive(true);
                Day.gameObject.SetActive(false);
                break;
            case 2:
                Night_Day.gameObject.SetActive(true);
                Day_Evening.gameObject.SetActive(false);
                Evening.gameObject.SetActive(false);
                break;
        }
    }
}
