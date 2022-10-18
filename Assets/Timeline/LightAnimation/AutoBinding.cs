using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class AutoBinding : MonoBehaviour
{
    public Transform Host;
    public PlayableDirector director;
    public TimelineAsset timeline;
    public RuntimeAnimatorController controller;
    public FindLinkToSearch findLinkToSearch;
    private void OnEnable()
    {
        director = GetComponent<PlayableDirector>();
        timeline = director.playableAsset as TimelineAsset;
        foreach (var track in timeline.GetOutputTracks())
        {
            if (director.GetGenericBinding(track) != null)
            {
                continue;
            }
            var target = Host.Find(track.name);
            var childCount = Host.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                target = Host.transform.GetChild(i).Find(track.name);
                if (target != null)
                {
                    break;
                }
            }
            if (target == null)
            {
                if (findLinkToSearch != null)
                    target = findLinkToSearch.GetLinkToSearch(track.name).gameObject.transform;
                continue;
            }
            if (target.TryGetComponent(out Animator targetAnimator))
            {
                targetAnimator.runtimeAnimatorController = controller;
            }
            else
            {
                targetAnimator.gameObject.AddComponent<Animator>().runtimeAnimatorController = controller;
            }
            director.SetGenericBinding(track, target.GetComponent<Animator>());
            if (director.GetGenericBinding(track) == null)
            {
                Debug.Log(director.GetGenericBinding(track).name);
            }
        }
    }
}
