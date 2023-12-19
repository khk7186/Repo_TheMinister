using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTrigger : MonoBehaviour
{
    public void JumpToMainMenu()
    {
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
        var manager = FindObjectOfType<SaveAndLoadManager>();
        yield return manager.StartCoroutine(manager.ResetScene());
        yield return new WaitUntil(() => animation.transition.GetCurrentAnimatorStateInfo(0).IsName("Wait"));
        SceneManager.LoadScene(0);
        yield return WaitUntilSceneLoad.WaitUntilScene(1);
        yield return new WaitForSeconds(0.5f);
        animation.Open();
    }
}
