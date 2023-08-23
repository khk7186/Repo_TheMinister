using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransController : MonoBehaviour
{
    //cc Ð¡³Â
    public Animator transition;
    public delegate IEnumerator SceneTransDelegate();
    public SceneTransDelegate transDelegate;

    public IEnumerator DestroyAfterPlay()
    {
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => transition.GetCurrentAnimatorStateInfo(0).IsName("NoAction"));
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Destroy");
        Destroy(GetComponentInParent<Canvas>().gameObject);
    }
    public void Open()
    {
        transition.Play("Open");
        //Debug.Log("Open");
        StartCoroutine(DestroyAfterPlay());
    }
    public void Close()
    {
        transition.Play("Close");
        //Debug.Log("Close");
        StartCoroutine(transDelegate());
    }

}
