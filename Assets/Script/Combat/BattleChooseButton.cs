using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleChooseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public CombatAction buttonAction = CombatAction.NoSelect;
    public void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<BattleSystem>().SetCurrentAction(buttonAction);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.yellow;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.white;
    }
}
