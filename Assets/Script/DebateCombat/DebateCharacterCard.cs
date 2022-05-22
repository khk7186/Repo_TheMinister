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
        CardUI = FindObjectOfType<DebateCharacterCardUI>();
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
        CardUI.cardBack.localScale = unit.isPlayer ? Vector3.zero : Vector3.one;
        CardUI.mainPannel.localScale = unit.isPlayer ? Vector3.one : Vector3.zero;
    }
    public void ShowCardFront()
    {
        CardUI.cardBack.localScale = unit.isPlayer ? Vector3.zero : Vector3.one;
        CardUI.mainPannel.localScale = unit.isPlayer ? Vector3.one : Vector3.zero;
    }

}
