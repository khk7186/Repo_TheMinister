using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSelectUI : MonoBehaviour
{
    public CombatCharacterUnit unit;
    public void Setup(Transform targetUnit)
    {
        SetPosition(targetUnit);
        unit = targetUnit.GetComponent<CombatCharacterUnit>();
    }
    private void SetPosition(Transform targetTransform)
    {
        var CanvasRect = MainCanvas.FindMainCanvas().GetComponent<RectTransform>();
        var MainCamera = Camera.main;
        var Position = targetTransform.position;
        Vector2 AP = WorldToCanvasPosition.GetCanvasPosition(CanvasRect, MainCamera, Position);
        AP.x -= 40;
        AP.y += 90;
        GetComponent<RectTransform>().anchoredPosition = AP;
    }
    private void Awake()
    {
        StartCoroutine(DestryoRator());
    }
    public IEnumerator DestryoRator()
    {
        var csc = FindObjectOfType<CombatSceneController>();
        csc.OnAction = true;
        yield return new WaitForEndOfFrame();
        while (true)
        {
            if (!IsPointerOver.IsPointerOverUIObject())
            {
                if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
                {
                    csc.OnAction = false;
                    GetComponent<RightClickToClose>().RightClickEvent();
                }
            }
            yield return null;
        }
    }
    public void Attack()
    {
        unit.currentAction = Action.Attack;
        var interactUnit = unit.GetComponent<CombatInteractableUnit>();
        if (interactUnit != null)
        {
            interactUnit.ChangeTarget();
        }
    }
    public void Defence()
    {
        unit.currentAction = Action.Defence;
        var interactUnit = unit.GetComponent<CombatInteractableUnit>();
        if (interactUnit != null)
        {
            interactUnit.ChangeTarget();
        }
    }
    public void Assassinate()
    {
        unit.currentAction = Action.Assassin;
        var interactUnit = unit.GetComponent<CombatInteractableUnit>();
        if (interactUnit != null)
        {
            interactUnit.ChangeTarget();
        }
    }
}
