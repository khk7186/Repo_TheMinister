using UnityEngine;
using UnityEngine.UI;

public class MoveCanvasImageWithMouse : MonoBehaviour
{
    public float xRange = 100f; // max movement in horizontal direction
    public float yRange = 100f; // max movement in vertical direction

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Normalize mouse position to range 0 - 1
        Vector2 normalizedMousePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

        // Convert normalized position to range -0.5 - 0.5
        Vector2 deltaPosition = new Vector2(normalizedMousePosition.x - 0.5f, normalizedMousePosition.y - 0.5f);

        // Map the normalized position to the desired range
        Vector2 targetPosition = new Vector2(deltaPosition.x * xRange * 2, deltaPosition.y * yRange * 2);

        rectTransform.anchoredPosition = targetPosition;
    }
}

