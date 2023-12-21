using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            SetLostEnemy();
            SetWinSkin();
            SetMoney();
            SetPressure();
            SetItem();
        }
        else
        {
            SetLostSkin();
            SetPunishment();
            ItemRewardHolder.gameObject.SetActive(false);
        }
        SetLostAlly();
    }

    private void SetPunishment()
    {
        string symbol = "";
        if (generalEventTrigger.moneyPunishment > 0) symbol = "+";
        MoneyRewardText.text = $"{symbol}{generalEventTrigger.moneyPunishment}";
        if (generalEventTrigger.pressurePunishment < 0) symbol = "";
        PressureRewardText.text = $"{symbol}{generalEventTrigger.pressurePunishment}";
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
        if (lostEnemy == null || lostEnemy.Count == 0)
        {
            LostEnemyHolder.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            foreach (Character character in lostEnemy)
            {
                var egpc = Instantiate(eGP_CharacterPrefab, LostEnemyHolder);
                egpc.Setup(character.characterArtCode);
                egpc.transform.localScale = Vector3.one;
                egpc.SetState(true);
            }
        }
    }

    private void SetLostAlly()
    {
        var lostAlly = generalEventTrigger.playerCharacters.Where(x => x.health <= 0).ToList();
        TransformEx.Clear(LostAllyHolder);
        if (lostAlly == null || lostAlly.Count == 0)
        {
            LostAllyHolder.transform.parent.gameObject.SetActive(false);
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
        string symbol = "";
        //if (generalEventTrigger.pressurePunishment > 0) symbol = "+";
        PressureRewardText.text = $"{symbol}{generalEventTrigger.pressureRewards.ToString()}%";
    }

    public void SetMoney()
    {
        string symbol = "";
        if (generalEventTrigger.moneyPunishment > 0) symbol = "+";
        MoneyRewardText.text = $"{symbol}{generalEventTrigger.moneyRewards.ToString()}";
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
    private void OnDestroy()
    {
        var lostAlly = generalEventTrigger.LostCharacters;
        foreach (Character character in lostAlly)
        {
            character.StartCoroutine(character.TryDeath());
            character.StartCoroutine(character.TryRetire());
        }
    }
}
