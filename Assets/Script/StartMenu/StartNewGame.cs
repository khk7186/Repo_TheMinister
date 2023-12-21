using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SaveSystem;
using PixelCrushers;

public class StartNewGame : MonoBehaviour
{
    public MainEventUnitProfile startProfile = null;
    public GameSave gameSave = null;
    public bool plainStart = true;
    public bool start = false;
    private void OnEnable()
    {
        gameSave = null;
    }
    private void Start()
    {
        gameSave = null;
    }
    public void StartAGame()
    {
        if (start) return;
        plainStart = true;
        string path = $"SceneTransPrefab/{SceneType.MainGame}/{SceneType.MainGame}Animation";
        var canvas = Instantiate(Resources.Load<Canvas>("SceneTransPrefab/Canvas"));
        DontDestroyOnLoad(canvas);
        var animation = Instantiate(Resources.Load<SceneTransController>(path), canvas.transform);
        animation.transDelegate = NextStep;
        animation.Close();
    }
    public void StartAGameWithSave(GameSave Save)
    {
        if (start) return;
        plainStart = false;
        gameSave = Save;
        string path = $"SceneTransPrefab/{SceneType.MainGame}/{SceneType.MainGame}Animation";
        var canvas = Instantiate(Resources.Load<Canvas>("SceneTransPrefab/Canvas"));
        DontDestroyOnLoad(canvas);
        var animation = Instantiate(Resources.Load<SceneTransController>(path), canvas.transform);
        animation.transDelegate = NextStep;
        animation.Close();
    }
    IEnumerator NextStep()
    {
        var animation = FindObjectOfType<SceneTransController>();
        yield return new WaitUntil(() => animation.transition.GetCurrentAnimatorStateInfo(0).IsName("Wait"));
        SceneManager.LoadScene(1);
        yield return WaitUntilSceneLoad.WaitUntilScene(1);
        if (plainStart)
        {
            var manager = FindObjectOfType<GameEventManager>();
            manager.nextEvent = startProfile;
            manager.NewGame();
            yield return new WaitForSeconds(0.5f);
            animation.Open();
        }
        else
        {
            //FindObjectOfType<SaveAndLoadManager>().LoadGame(gameSave);
            var manager = FindObjectOfType<SaveAndLoadManager>();
            yield return manager.ResetScene();
            manager.LoadGame(gameSave);
            yield return new WaitForSeconds(2);
            animation.Open();
        }
    }
}
