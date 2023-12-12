using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeserializeSave
{
    public static GameSave LoadSave(string json)
    {
        GameSave output = JsonUtility.FromJson(json, typeof(GameSave)) as GameSave;
        return output;
    }
}
