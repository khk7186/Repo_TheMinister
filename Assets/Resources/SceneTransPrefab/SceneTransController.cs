using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransController : MonoBehaviour
{
    //cc Ð¡³Â
    public Animator transition;

    private void OnEnable()
    {
        Close();
    }

    public void Open()
    {
        transition.Play("Open");
        StartCoroutine(DestroyAfterPlay());
    }

    public IEnumerator DestroyAfterPlay()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

    public void Close()
    {
        transition.Play("Close");
    }

}
