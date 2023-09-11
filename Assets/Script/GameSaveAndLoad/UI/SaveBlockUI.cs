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

    public void Setup()
    {
        SaveName.text = save.saveName;
        PreviewSaveTime.text = save.saveTime;
        PreviewMoney.text = save.Money.ToString();
        PreviewCharacterCount.text = save.playerOwnedCharacters.Count.ToString();
    }

    public void Save()
    {
        FindObjectOfType<SaveAndLoadManager>().SaveGame(SaveName.text);
        FindObjectOfType<GameSaveUIController>().OnEnable();
        
    }
}
