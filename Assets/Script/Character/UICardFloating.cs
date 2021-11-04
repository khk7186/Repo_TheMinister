using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICardFloating : MonoBehaviour
{
    public float floatingRange = 5f;
    public float randomNoise = 5f;
    public float speed = 2f;
    private float noise;

    private RectTransform rectTransform;
    private Vector2 origin;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        origin = rectTransform.anchoredPosition;
        noise = Random.Range(0, randomNoise);
    }
    private void Update()
    {
        rectTransform.anchoredPosition = new Vector2(origin.x, origin.y + Mathf.Sin((Time.time + noise)*speed) * floatingRange);
    }
}
