using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    public void StartAGame()
    {
        StartCoroutine(JumpToScene());
    }
    private IEnumerator JumpToScene()
    {
        //Debug.Log("Start SceneChangeAnimation");
        string path = $"CombatScene/SceneChangeAnimation";
        var animation = Instantiate(Resources.Load<SceneTrans>(path));
        yield return StartCoroutine(animation.StartChange(SceneType.MainGame));
        SceneManager.LoadScene(1);
        yield return StartCoroutine(animation.EndChange());
    }
}
