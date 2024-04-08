using Language.Lua;
using SaveSystem;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SerializeSave
{
    public static bool SaveData(GameSave gameSave)
    {
        //string projectRootPath = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/Assets/SaveData"));
        //QuickSaveWriter.Create(gameSave.saveName)
        //                                                .Write(gameSave.saveTime, gameSave)
        //                                                .Commit();
        string jsonData = JsonUtility.ToJson(gameSave);
        string path = $"{Application.persistentDataPath}/Save";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        Debug.Log(Application.persistentDataPath);
        string filePath = $"{path}/{gameSave.saveTime.Replace("/", string.Empty).Replace(":", string.Empty).Replace(" ", string.Empty)}.json";
        System.IO.File.WriteAllText(filePath, jsonData);
        return false;
    }
    public static bool SaveSetting(SettingSave settingSave)
    {
        string jsonData = JsonUtility.ToJson(settingSave);
        string path = $"{Application.persistentDataPath}/Settings";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        if (System.IO.File.Exists($"{path}/Setting.json"))
        {
            System.IO.File.Delete($"{path}/Setting.json");
        }
        Debug.Log(Application.persistentDataPath);
        string filePath = $"{path}/Setting.json";
        System.IO.File.WriteAllText(filePath, jsonData);
        return false;
    }
    public static SettingSave LoadSetting()
    {
        string path = $"{Application.persistentDataPath}/Settings/Setting.json";
        if (!System.IO.File.Exists(path))
        {
            SaveSetting(new SettingSave());
        }
        var file = System.IO.File.ReadAllText(path);
        var settingSave = JsonUtility.FromJson(file, typeof(SettingSave)) as SettingSave;
        return settingSave;
    }
}
[Serializable]
public class SettingSave
{
    public float musicVolume = 0.8f;
    public float sfxVolume = 0.8f;
    public float masterVolume = 0.8f;
    public int resolutionIndex = 1;
    public int displayIndex = 0;
}
