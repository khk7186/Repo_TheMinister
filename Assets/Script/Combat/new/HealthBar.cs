using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Transform followCharacter;
    public RectTransform selfRT;
    private RectTransform canvas;
    private Camera MainCamera;
    public float duration = 0.1f;

    private void Awake()
    {
        MainCamera = Camera.main;
        selfRT = GetComponent<RectTransform>();
        canvas = MainCanvas.FindMainCanvas().GetComponent<RectTransform>();
    }
    public void Setup(int health)
    {
        StartCoroutine(healthChange(health));
    }
    IEnumerator healthChange(int health)
    {
        bool costHealth = health < slider.value;
        if (costHealth)
        {
            var target = slider.value - health;
            while (target > 0)
            {
                target--;
                slider.value -= 1;
                yield return new WaitForSeconds(duration);
            }
        }
        else
        {
            var target = health - slider.value;
            while (target < health)
            {
                target++;
                slider.value += 1;
                yield return new WaitForSeconds(duration);
            }
        }

    }

    private void Update()
    {
        var Position = followCharacter.position;
        Vector2 AP = WorldToCanvasPosition.GetCanvasPosition(canvas, MainCamera, Position);
        AP.y += 100;
        selfRT.anchoredPosition = AP;
    }
}
