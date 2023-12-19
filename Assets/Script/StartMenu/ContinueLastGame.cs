using PixelCrushers;
using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueLastGame : MonoBehaviour
{
    public GameSave gameSave = null;
    private IEnumerator Start()
    {
        var db = FindObjectOfType<GameSaveUIController>(true).GameSaveDatabase;
        GetComponentInChildren<Text>().color = new Color(225, 215, 170, 0);
        db.FindAllSaves();
        yield return new WaitUntil(() => db.gameSaves.Count > 0);
        gameSave = db.FindLatest();
        GetComponentInChildren<Text>().color = new Color(225, 215, 170, 1);

    }
    public void Continue()
    {
        FindObjectOfType<StartNewGame>().StartAGameWithSave(gameSave);
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
