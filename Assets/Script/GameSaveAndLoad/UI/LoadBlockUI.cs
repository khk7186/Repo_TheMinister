using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        bool OnMainScene = SceneManager.GetActiveScene().buildIndex == 1;
        if (OnMainScene)
        {
            FindObjectOfType<SaveAndLoadManager>().ReloadMainScene(save);
            gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<StartNewGame>().StartAGame(save);
        }
    }

    public void Remove()
    {
        bool OnMainScene = SceneManager.GetActiveScene().buildIndex == 1;
        if (OnMainScene)
        {
            DeleteGame(save);
        }
        else
        {
            DeleteGame(save);
        }

    }
    public void DeleteGame(GameSave save)
    {
        string path = $"{Application.persistentDataPath}/Save";
        string filePath = $"{path}/{save.saveTime.Replace("/", string.Empty).Replace(":", string.Empty).Replace(" ", string.Empty)}.json";
        Debug.Log(filePath);
        if (System.IO.File.Exists(filePath))
        {
            Debug.Log("exist");
            System.IO.File.Delete(filePath);
        }
    }
}
