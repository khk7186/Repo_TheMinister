using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagDescriptionUI : MonoBehaviour
{
    public Image tagImage;
    public Text tagStats;
    private Tag currentTag = Tag.Null;
    public Vector2 offset = new Vector2(15, -15);  // Offset from the mouse position
    private RectTransform imageRectTransform;
    private RectTransform canvasRectTransform;
    private void Awake()
    {
        imageRectTransform = GetComponent<RectTransform>();
        canvasRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    public static void Show(string tag)
    {
        var ui = FindObjectOfType<TagDescriptionUI>(true);
        ui.Setup(tag);
        ui.SetPositionNextToMouse();
        ui.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        FindObjectOfType<TagDescriptionUI>().gameObject.SetActive(false);
    }
    private void Setup(string tag)
    {
        var targetTag = (Tag)Enum.Parse(typeof(Tag), tag);
        if (currentTag != targetTag)
        {
            currentTag = targetTag;
            tagImage.sprite = Resources.Load<Sprite>(ReturnAssetPath.ReturnTagPath(currentTag));
            tagStats.text = ItemStatPrinter.PrintAllStats(currentTag);
        }
    }
    private void Update()
    {
        SetPositionNextToMouse();
    }
    public void SetPositionNextToMouse()
    {
        if (imageRectTransform == null) return;
        // Convert mouse position to canvas space
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform,
            Input.mousePosition,
            null,
            out mousePos);

        // Add the offset to the mouse position
        mousePos += offset;

        // Set the anchored position based on mouse
        imageRectTransform.anchoredPosition = mousePos;

        // Clamp the position so the UI stays within the screen bounds
        Vector2 clampedPosition = imageRectTransform.anchoredPosition;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -canvasRectTransform.sizeDelta.x / 2 + imageRectTransform.sizeDelta.x / 2, canvasRectTransform.sizeDelta.x / 2 - imageRectTransform.sizeDelta.x / 2);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -canvasRectTransform.sizeDelta.y / 2 + imageRectTransform.sizeDelta.y / 2, canvasRectTransform.sizeDelta.y / 2 - imageRectTransform.sizeDelta.y / 2);
        imageRectTransform.anchoredPosition = clampedPosition;
    }
}
