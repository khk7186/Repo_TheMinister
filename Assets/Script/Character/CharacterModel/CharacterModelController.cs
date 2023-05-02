using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine.Unity.Examples;

public class CharacterModelController : MonoBehaviour
{
    public SkeletonMecanim front;
    public GameObject frontOutline;
    public SkeletonMecanim back;
    public GameObject backOutline;
    public SkeletonMecanim current;
    public string SkinName = "face-normal expression";


    private void Awake()
    {
        SkinName = "face-normal expression";
        current = front;
        frontOutline = front.GetComponentInChildren<RenderExistingMesh>(true)?.gameObject;
        backOutline = back.GetComponentInChildren<RenderExistingMesh>(true)?.gameObject;
    }
    private void OnEnable()
    {
        if (frontOutline != null && backOutline != null)
        {
            UndrawOutline();
        }
        SetCurrent();
    }

    public void DrawOutline()
    {
        if (frontOutline == null) return;
        frontOutline.SetActive(true);
        backOutline.SetActive(true);
    }
    public void UndrawOutline()
    {
        if (frontOutline == null) return;
        frontOutline.SetActive(false);
        backOutline.SetActive(false);
    }
    public void SetCurrent()
    {
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
    public void SetTrigger(string trigger)
    {
        front.GetComponent<Animator>().SetTrigger(trigger);
        back.GetComponent<Animator>().SetTrigger(trigger);
    }
}
