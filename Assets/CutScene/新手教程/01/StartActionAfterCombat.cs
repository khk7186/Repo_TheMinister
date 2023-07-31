using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartActionAfterCombat : MonoBehaviour
{
    public GeneralEventTrigger GETrigger;
    public List<GameObject> _objectsToActive;
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => GETrigger.gameTracker != null);
        yield return new WaitUntil(() => GETrigger.gameTracker.gameWin == true);
        yield return new WaitUntil(() => SceneManager.GetActiveScene().buildIndex == 1);
        MainCanvas.FindMainCanvas().gameObject.SetActive(false);
        foreach (var obj in _objectsToActive)
        {
            obj.SetActive(true);
        }
        yield return null;
    }
}
