using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePannel : MonoBehaviour
{
    public Transform LostAllyHolder;
    public Transform LostEnemyHolder;
    public EGP_Character eGP_CharacterPrefab;

    public Text MoneyRewardText;
    public Text PressureRewardText;

    public Transform ItemRewardHolder;
    public ItemUI ItemUIPrefab;

    public GameObject WinSkin;
    public GameObject LostSkin;

    private GeneralEventTrigger generalEventTrigger;
    private void Start()
    {
        eGP_CharacterPrefab.gameObject.SetActive(false);
    }

    public void Setup(GeneralEventTrigger generalEventTrigger)
    {
        this.generalEventTrigger = generalEventTrigger;
        if (generalEventTrigger.gameTracker.gameWin)
        {
            SetWinSkin();
            SetMoney();
            SetPressure();
        }
        else
        {
            SetLostSkin();
            SetPunishment();
        }
        SetItem();
        SetLostAlly();
        SetLostEnemy();
    }

    private void SetPunishment()
    {
        MoneyRewardText.text = $"{generalEventTrigger.moneyPunishment}";
        PressureRewardText.text = $"+{generalEventTrigger.pressurePunishment}";
    }

    private void SetLostSkin()
    {
        LostSkin.SetActive(true);
        WinSkin.SetActive(false);
    }

    private void SetWinSkin()
    {
        WinSkin.SetActive(true);
        LostSkin.SetActive(false);
    }
    private void SetLostEnemy()
    {
        var lostEnemy = generalEventTrigger.enemyCharacters;
        TransformEx.Clear(LostEnemyHolder);
        foreach (var character in lostEnemy)
        {
            var egpc = Instantiate(eGP_CharacterPrefab, LostEnemyHolder);
            egpc.Setup(character.characterArtCode);
            egpc.transform.localScale = Vector3.one;
            egpc.SetState(true);
        }
    }

    private void SetLostAlly()
    {
        var lostAlly = generalEventTrigger.LostCharacters;
        TransformEx.Clear(LostAllyHolder);
        if (lostAlly == null || lostAlly.Count == 0)
        {
            LostAllyHolder.gameObject.SetActive(false);
        }
        else
        {
            foreach (Character character in lostAlly)
            {
                var egpc = Instantiate(eGP_CharacterPrefab, LostAllyHolder);
                egpc.transform.localScale = Vector3.one;
                egpc.Setup(character.characterArtCode);
                egpc.SetTransparent(true);
            }
        }
    }

    private void SetPressure()
    {
        PressureRewardText.text = $"-{generalEventTrigger.pressureRewards.ToString()}%";
    }

    public void SetMoney()
    {
        MoneyRewardText.text = $"+{generalEventTrigger.moneyRewards.ToString()}";
    }
    public void SetItem()
    {
        var items = generalEventTrigger.itemRewards;
        if (items == null || items.Count == 0)
        {
            ItemRewardHolder.gameObject.SetActive(false);
        }
        else
        {
            foreach (var item in items)
            {
                var itemUI = Instantiate(ItemUIPrefab, ItemRewardHolder);
                itemUI.Setup(item);
            }
        }
    }
}
