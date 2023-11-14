using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DestroyObjectAfterVideo : MonoBehaviour
{
    public double time = 0;
    public double currentTime = 0;
    public List<GameObject> gameObjectsToDestroy;
    public double lastRecordTime = 0;
    // Use this for initialization
    void Start()
    {

        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }


    // Update is called once per frame
    void Update()
    {
        lastRecordTime = currentTime;
        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime == lastRecordTime) currentTime += 0.1f;
        if (currentTime >= time)
        {
            foreach (GameObject gameObject in gameObjectsToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
