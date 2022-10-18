using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BindByLTS : MonoBehaviour
{
    public bool bindOnEable = false;
    public FindLinkToSearch ltsStorage;
    public PlayableDirector pd; 
    public TimelineAsset timeline;
    public void OnEnable()
    {
        if (bindOnEable)
        {
            Bind();
        }
    }
    public void Bind()
    {
        pd = GetComponent<PlayableDirector>();
        timeline = pd.playableAsset as TimelineAsset;
        foreach (var track in timeline.GetOutputTracks())
        {
            if (pd.GetGenericBinding(track) != null)
            {
                continue;
            }
            var temp = ltsStorage?.GetLinkToSearch(track.name);
            if (temp != null)
            {
                pd.SetGenericBinding(track, temp.GetComponent<Animator>());
            }
        }
    }
}
