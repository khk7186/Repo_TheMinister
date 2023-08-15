using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDescriptionUI : MonoBehaviour
{
    public string Target = string.Empty;
    public string Description = "Nathan忘了加这段的描述了";

    private void Update()
    {
        SetPositionNextToMouse();
    }
    public void SetPositionNextToMouse()
    {
        transform.position = Input.mousePosition;
    }
    public static void Show(string target)
    {
        var ui = GameObject.FindObjectOfType<MenuDescriptionUI>(true);
        ui.Target = target;
        ui.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        GameObject.FindObjectOfType<ItemDetailUI>(true).gameObject.SetActive(false);
    }
}
