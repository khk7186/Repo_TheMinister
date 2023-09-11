using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveBlockUI : MonoBehaviour
{
    public Text SaveName;
    public Text PreviewSaveTime;
    public Text PreviewMoney;
    public Text PreviewPressure;
    public Text PreviewCharacterCount;

    public GameSave save;

    private void OnEnable()
    {
        Setup();
    }
    public void Setup()
    {
        SaveName.text = save.saveName;
        PreviewSaveTime.text = save.saveTime;
        PreviewMoney.text = FindObjectOfType<CurrencyInventory>().Money.ToString();
        PreviewPressure.text = $"{PressureManager.Instance.pressure.ToString()}%";
        PreviewCharacterCount.text = FindObjectOfType<CurrencyInventory>().Prestige.ToString();
    }

    public void Save()
    {
        FindObjectOfType<SaveAndLoadManager>().SaveGame(SaveName.text);
        FindObjectOfType<GameSaveUIController>().OnEnable();

    }
}
