using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEventManager : MonoBehaviour
{
    public static MapEventManager Instance;
    public MoneyCollectPoint[] points;
    public Transform canvas;
    public Queue<string> messageQueue = new Queue<string>();

    private void Start()
    {
        points = FindObjectsOfType<MoneyCollectPoint>();
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    private void OnEnable()
    {
        canvas = MainCanvas.FindMainCanvas();
    }
    private void Update()
    {
        if (messageQueue.Count > 0)
        {
            string message = messageQueue.Dequeue();
            GameObject messageObject = Instantiate(Resources.Load("MoneyCollectMessage") as GameObject, canvas);
        }
    }

}
