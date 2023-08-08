using UnityEngine;
using UnityEngine.UI;
public class FloatCanvasImage : MonoBehaviour
{
    public float amplitude = 10f; // How much the image will move up and down
    public float minSpeed = 0.5f; // Minimum speed of the movement
    public float maxSpeed = 1.5f; // Maximum speed of the movement

    private RectTransform rectTransform;
    private float initialY;
    private float speed;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialY = rectTransform.anchoredPosition.y;

        // Randomize the speed between minSpeed and maxSpeed
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        float newY = initialY + Mathf.Sin(Time.time * speed) * amplitude;
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);
    }
}