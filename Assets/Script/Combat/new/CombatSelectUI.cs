using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSelectUI : MonoBehaviour
{
    public CombatCharacterUnit characterUnit;
    public void Setup(Transform targetUnit)
    {
        SetPosition(targetUnit);
    }
    private void SetPosition(Transform targetTransform)
    {
        var CanvasRect = MainCanvas.FindMainCanvas().GetComponent<RectTransform>();
        var MainCamera = Camera.main;
        var Position = targetTransform.position;
        Vector2 AP = WorldToCanvasPosition.GetCanvasPosition(CanvasRect, MainCamera, Position);
        AP.x += 40;
        AP.y += 35;
        GetComponent<RectTransform>().anchoredPosition = AP;
    }
    private void Awake()
    {
        StartCoroutine(DestryoRator());
    }
    public IEnumerator DestryoRator()
    {
        yield return new WaitForEndOfFrame();
        while (true)
        {
            if (!IsPointerOver.IsPointerOverUIObject())
            {
                if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
                {
                    GetComponent<RightClickToClose>().RightClickEvent();   
                }
            }
            yield return null;
        }
    }
    public void Attack()
    {
        CombatSystem battleSystem = FindObjectOfType<CombatSystem>();
        if (battleSystem != null)
        {

        }
    }
    public void Defence()
    {
        CombatSystem battleSystem = FindObjectOfType<CombatSystem>();
        if (battleSystem != null)
        {

        }
    }
    public void Assassinate()
    {
        CombatSystem battleSystem = FindObjectOfType<CombatSystem>();
        if (battleSystem != null)
        {

        }
    }
}
