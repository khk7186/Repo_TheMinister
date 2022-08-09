using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class IETest : MonoBehaviour
{
    public List<GameObject> offObjects;
    public GameObject currentOn;
    //public List<AnimatorScript> allAnimators
    public void ManagerAction(GameObject go)
    {

        //1=> currentOn = go
        //2=> forloop (offObjects) 
        //        if not currentOn&&gameobject.active == true => Action()
        //        if true => go.setactive
    }

    public IEnumerator Actionrator()
    {
        //ANIMATION ON
        float duration = 3f;
        yield return new WaitForSeconds(duration);
        foreach (GameObject go in offObjects)
        {
            if (go == currentOn)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }
    }
}
