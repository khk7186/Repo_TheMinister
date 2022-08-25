using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Cinemachine;

public class FindPlayerOnStart : MonoBehaviour
{
    public Transform Host;
    public PlayableDirector director;
    public TimelineAsset timeline;
    public GameObject _dialogue;
    private void Start()
    {
        director = GetComponent<PlayableDirector>();
        timeline = director.playableAsset as TimelineAsset;
        foreach (var track in timeline.GetOutputTracks())
        {
            if (director.GetGenericBinding(track) != null)
            {
                continue;
            }
            switch (track.name)
            {
                case "摄像机":
                    director.SetGenericBinding(track, Host.Find(track.name).GetComponent<Animator>());
                    break;
                case "李袁陌":
                    director.SetGenericBinding(track, GameObject.FindGameObjectWithTag("Player"));
                    break;
                case "对话":
                    director.SetGenericBinding(track, _dialogue);
                    break;
                case "Self":
                    director.SetGenericBinding(track, gameObject);
                    break;
            }
        }
    }
}
