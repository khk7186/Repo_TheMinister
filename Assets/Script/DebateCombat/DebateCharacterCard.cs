using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DebateCharacterCard : MonoBehaviour
{
    public DebateCharacterCardUI CardUI;
    public DebateUnit unit;
    public Character character;
    public int UseCount = 0;
    public void Setup(Character character)
    {
        this.character = character;
        CardUI = GetComponent<DebateCharacterCardUI>();
        CardUI.Setup(this);
        SpawnCardAtStart();
    }
    public void SpawnCardAtStart()
    {
        bool isPlayer = unit.isPlayer;
        if (isPlayer)
        {
            ShowCardFront();
        }
        else
        {
            ShowCardBack();
        }
        CardUI.Setup(this);
    }
    public void ShowCardBack()
    {
        CardUI.cardBack.localScale = Vector3.one;
        CardUI.cardBack.gameObject.SetActive(true);
        CardUI.mainPannel.localScale = Vector3.zero;
        CardUI.mainPannel.gameObject.SetActive(false);
    }
    public void ShowCardFront()
    {
        CardUI.cardBack.localScale = Vector3.zero;
        CardUI.cardBack.gameObject.SetActive(false);
        CardUI.mainPannel.localScale = Vector3.one;
        CardUI.mainPannel.gameObject.SetActive(true);        
    }
}
