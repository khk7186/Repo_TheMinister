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
        if (GameEventManager.Instance.SaveReady == false)
        {
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            alert.text = "主线剧情期间无法保存游戏";
            return;
        }
        FindObjectOfType<SaveAndLoadManager>().SaveGame(SaveName.text);
        FindObjectOfType<GameSaveUIController>().OnEnable();

    }
}
