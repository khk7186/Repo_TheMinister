using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class CharacterModelController : MonoBehaviour
{
    public SkeletonMecanim front;
    public SkeletonMecanim back;
    public SkeletonMecanim current;

    private void Awake()
    {
        current = front;
        front.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        back.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }

    public void SetFront()
    {
        current = front;
    }
    public void SetBack()
    {
        current = back;
    }
}
