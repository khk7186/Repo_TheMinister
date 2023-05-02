using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class CharacterModelController : MonoBehaviour
{
    public SkeletonMecanim front;
    public SkeletonMecanim back;
    public SkeletonMecanim current;
    public string SkinName = "face-normal expression";


    private void Awake()
    {
        SkinName = "face-normal expression";
        current = front;
    }
    private void OnEnable()
    {
        SetCurrent();
    }
    public void SetCurrent()
    {
        Debug.Log($"SetCurrent:{current.name}");
        if (current == front)
        {
            back.transform.localScale = new Vector3(0f, 0.7f, 0.7f);
            front.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        else if (current == back)
        {
            front.transform.localScale = new Vector3(1f, 0f, 0f);
            back.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        SetSkin();
    }
    public void SetFront()
    {
        current = front;
        SetSkin();
    }
    public void SetBack()
    {
        current = back;
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            SetCurrent();
        }
    }
    public void SetSkin(string skinName = null)
    {
        if (!string.IsNullOrEmpty(skinName)) this.SkinName = skinName;
        current.Skeleton.SetSkin(SkinName);
        current.Skeleton.SetSlotsToSetupPose();
        current.LateUpdate();
    }
}
