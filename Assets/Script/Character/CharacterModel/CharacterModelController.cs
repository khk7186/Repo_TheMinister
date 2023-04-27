using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class CharacterModelController : MonoBehaviour
{
    public SkeletonMecanim front;
    public SkeletonMecanim back;
    public SkeletonMecanim current
    {
        get
        {
            return front.gameObject.activeSelf ? front : back;
        }
    }

    private void Awake()
    {
        back.gameObject.SetActive(false);
    }

    public void SetFront()
    {
        front.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
    }
    public void SetBack()
    {
        front.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
    }
}
