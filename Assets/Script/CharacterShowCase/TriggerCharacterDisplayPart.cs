using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCharacterDisplayPart : MonoBehaviour
{
    public List<DisplayInfoAnimationController> displayInfos = new List<DisplayInfoAnimationController>();

    public bool TriggerOnEnable = false;
    public float displayTime = 2f;

    public void OnEnable()
    {
        if (TriggerOnEnable)
        {
            StartCoroutine(ShowFrezzeHide());
        }
    }
    public void Show()
    {
        foreach (var item in displayInfos)
        {
            item.Show();
        }
    }
    public void Hide()
    {
        foreach (var item in displayInfos)
        {
            item.Hide();
        }
    }
    public IEnumerator ShowFrezzeHide()
    {
        Show();
        yield return new WaitForSeconds(0.2f);
        AudioManager.Play("´ò¿ª²Ëµ¥", false);
        var freeze = TimeFreeze.StartATimeFreeze(gameObject, displayTime);
        yield return freeze.StartCoroutine(freeze.FreezeTimeForSeconds(freeze.waitTime));
        Hide();
    }
}
