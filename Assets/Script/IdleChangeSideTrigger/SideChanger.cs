using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SideChanger : MonoBehaviour
{
    public Animator animator;
    public SkeletonMecanim skeletonMecanim;

    public void changeSide(bool front, bool right)
    {
        Debug.Log(1);
        if (TryGetComponent<DefaultInGameAI>(out var inGameAI))
        {
            CharacterArtCode CAC=  inGameAI.character.characterArtCode;
            string side = front ? "Front" : "Back";
            SkeletonDataAsset asset = Resources.Load<SkeletonDataAsset>
    ($"{ReturnAssetPath.ReturnSpineAssetPath(CAC, front)}{CAC}_{side}_SkeletonData");
            animator.GetComponent<SkeletonMecanim>().skeletonDataAsset = asset;
            string controllerPath = $"{ReturnAssetPath.ReturnSpineAssetPath(CAC, true)}{CAC}_{side}_Controller";
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(controllerPath);
            Vector3 target = animator.transform.localScale;
            target = new Vector3((right ? -0.7f : 0.7f), target.y, target.z);
            animator.transform.localScale = target;
            animator.GetComponent<SkeletonMecanim>().Initialize(true);
        }
        else
        {
            FindObjectOfType<Map>().ChangeSide(front, !right);
        }
    }
}
