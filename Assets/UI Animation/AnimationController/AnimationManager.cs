using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    //cc Ð¡³Â
    public List<GameObject> offObject;
    public GameObject OnCurrent;
    AnimationController Leave;


    private void FixedUpdate()
    {
        //OnCurrent = this.gameObject;
        Leave = OnCurrent.GetComponent<AnimationController>();
    }

    public void ManagerAction(GameObject OnNext)
    {
        foreach (GameObject obj in offObject)
        {
            if (OnNext == obj && obj.activeSelf == false && OnNext.activeSelf == false)
            {
                Action(obj);
            }
        }
    }

    public void Action(GameObject OnNext)
    {
        StartCoroutine(Actionrator(OnNext));
    }

    public IEnumerator Actionrator(GameObject OnNext)
    {
        Leave.Outro();
        float duration = 0.55f; 
        OnNext.SetActive(true);
        yield return new WaitForSeconds(duration);
        OnCurrent.SetActive(false);

        OnCurrent = OnNext;
    }
}
