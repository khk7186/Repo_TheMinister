using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnQuestNoticeClosed : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> gameObjects = new List<GameObject>();
    private void OnEnable()
    {
        StartCoroutine(OnEnableCoroutine());
    }

    private IEnumerator OnEnableCoroutine()
    {
        yield return new WaitForFixedUpdate();
        var notice = FindObjectOfType<QuestNotice>();
        yield return new WaitUntil(() => notice.gameObject.activeSelf == false);
        foreach (var obj in gameObjects)
        {
            obj.gameObject.SetActive(true);
        }
    }
}
