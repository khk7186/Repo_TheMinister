using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class IETest : MonoBehaviour
{
    private void Start()
    {
        Action();
    }
    public void Action()
    {
        StartCoroutine(Actionrator());
    }

    public IEnumerator Actionrator()
    {
        //ANIMATION ON
        float duration = 3f;
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
