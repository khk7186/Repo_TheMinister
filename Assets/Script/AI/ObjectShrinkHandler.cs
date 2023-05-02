using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShrinkHandler : MonoBehaviour
{
    public delegate void AfterShrink();
    public List<AfterShrink> afterShrinkTasks;
    public bool shringOnEnable = false;
    public GameObject targetObject;
    private void OnEnable()
    {
        if (shringOnEnable)
        {
            if (targetObject != null)
                Shrink(0f, 0.5f, targetObject);
        }
    }
    public void Shrink(float end, float duration, GameObject gameObject = null, List<AfterShrink> afterShrink = null)
    {
        afterShrinkTasks = afterShrink;
        StartCoroutine(ShrinkRator(end, duration, gameObject));
    }
    public IEnumerator ShrinkRator(float end, float duration, GameObject gameObject = null)
    {
        if (gameObject == null)
            gameObject = this.gameObject;
        Vector3 startScale = gameObject.transform.localScale;
        Vector3 endScale = new Vector3(startScale.x * end, startScale.y * end, startScale.z * end);
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            gameObject.transform.localScale = Vector3.Lerp(startScale, endScale, time / duration);
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        if (afterShrinkTasks != null)
        {
            foreach (AfterShrink afterShrink in afterShrinkTasks)
            {
                afterShrink.Invoke();
            }
        }
    }
}
