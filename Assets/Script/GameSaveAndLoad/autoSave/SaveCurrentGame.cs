using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveCurrentGame : MonoBehaviour
{
    public bool SaveOnEnable = false;
    public string SaveName = "自动存档";
    private void OnEnable()
    {
        if (SaveOnEnable)
        {
            Save();
        }
    }
    public void Save()
    {
        if (GameEventManager.Instance.SaveReady == false)
        {
            return;
        }
        else
        {
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            alert.text = "进度已保存";
            FindObjectOfType<SaveAndLoadManager>().SaveGame(SaveName);
        }
    }
}
