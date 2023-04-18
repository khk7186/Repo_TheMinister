using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;

public class ChangeSpineAlpha : MonoBehaviour
{
    public SkeletonMecanim skeletonMecanim;
    public SkeletonAnimation SkeletonAnimation;
    public void Start()
    {
        SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
        Spine.Skeleton skeleton = skeletonAnimation.skeleton;
        skeleton.A = 0.5f;
    }
}
