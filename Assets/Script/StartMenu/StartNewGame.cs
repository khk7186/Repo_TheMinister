using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    public void StartAGame()
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
        yield return new WaitUntil(() => animation.transition.GetCurrentAnimatorStateInfo(0).IsName("Wait"));
        SceneManager.LoadScene(1);
        yield return WaitUntilSceneLoad.WaitUntilScene(1);
        yield return new WaitForSeconds(0.5f);
        animation.Open();
    }
}
