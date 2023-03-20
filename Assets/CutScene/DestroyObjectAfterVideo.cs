using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DestroyObjectAfterVideo : MonoBehaviour
{
    public double time;
    public double currentTime;
    public List<GameObject> gameObjectsToDestroy;
    // Use this for initialization
    void Start()
    {

        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }


    // Update is called once per frame
    void Update()
    {
        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime >= time)
        {
            foreach (GameObject gameObject in gameObjectsToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
