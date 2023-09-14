using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadBlockUI : MonoBehaviour
{
    public Text SaveName;
    public Text SaveTime;
    public Text Money;
    public Text Pressure;
    public Text CharacterCount;

    public GameSave save;
    public void Setup(GameSave save)
    {
        this.save = save;
        SaveName.text = save.saveName;
        SaveTime.text = save.saveTime;
        Pressure.text = $"{save.Pressure.ToString()}%";
        Money.text = save.Money.ToString();
        CharacterCount.text = save.playerOwnedCharacters.Count.ToString();
        gameObject.SetActive(true);
    }

    public void Load()
    {
        FindObjectOfType<SaveAndLoadManager>().ReloadMainScene(save);
        Debug.Log("LogButton");
        gameObject.SetActive(false);
    }

    public void Remove()
    {
        FindObjectOfType<SaveAndLoadManager>().DeleteGame(save);
        gameObject.SetActive(false);
    }
}
