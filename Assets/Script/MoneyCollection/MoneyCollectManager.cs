using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoneyCollectManager : MonoBehaviour, IDiceRollEvent
{
    public static MoneyCollectManager Instance;
    public MoneyCollectPoint[] points;
    public Character characterTemp;
    public float MoneyDecreaseOnRoit = 1f;
    public int numeratorOfRiot = 1;
    public int denominatorOfRiot = 1;
    [Header("Animation")]
    public int YChange = 1000;
    public float duration = 0.3f;
    public float delay = 1.5f;
    public AnimationCurve curve;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        Dice.Instance.RegisterObserver(this);
        Reset();
    }
    public void LinkCamera()
    {
        var WScanvas = FindObjectsOfType<Canvas>().Where(x=>x.renderMode == RenderMode.WorldSpace);
        foreach (var x in WScanvas)
        {
            x.worldCamera = Camera.main;
        }
    }
    private void Reset()
    {
        points = FindObjectsOfType<MoneyCollectPoint>();
    }
    private void UpdateRoit()
    {
        foreach (MoneyCollectPoint point in points)
        {
            if (Random.Range(0, denominatorOfRiot) < numeratorOfRiot)
            {
                //point.SpawnRoit();
            }
        }
    }

    public void OnNotify(object value, NotificationType notificationType)
    {
        UpdateRoit();
    }
}
