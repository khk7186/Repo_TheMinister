using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBlockUI : MonoBehaviour
{
    public Text SaveName;
    public Text SaveTime;
    public Text Money;
    public Text Pressure;
    public Text CharacterCount;

    public SOGameSave save;
    public void Setup(SOGameSave save)
    {
        this.save = save;
        SaveName.text = save.saveName;
        SaveTime.text = save.saveTime;
        Money.text = save.Money.ToString();
        CharacterCount.text = save.playerOwnedCharacters.Count.ToString();
        gameObject.SetActive(true);
    }

    public void Load()
    {
        FindObjectOfType<SaveAndLoadManager>().LoadGame(save);
    }
}
