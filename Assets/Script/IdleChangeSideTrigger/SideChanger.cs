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
        if (TryGetComponent<DefaultInGameAI>(out var inGameAI))
        {
            bool isMoving = animator.GetBool("Move") == true;
            animator.SetTrigger("Stop");
            CharacterArtCode CAC = inGameAI.character.characterArtCode;
            string side = front ? "Front" : "Back";
            SkeletonDataAsset asset = Resources.Load<SkeletonDataAsset>
    ($"{ReturnAssetPath.ReturnSpineAssetPath(CAC, front)}");
            animator.GetComponent<SkeletonMecanim>().skeletonDataAsset = asset;
            string controllerPath = $"{ReturnAssetPath.ReturnSpineControllerPath(CAC, true)}";
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(controllerPath);
            animator.GetComponent<SkeletonMecanim>().Initialize(true);
            Vector3 target = animator.transform.localScale;
            target = new Vector3((right ? -0.7f : 0.7f), target.y, target.z);
            animator.transform.localScale = target;
            animator.GetComponent<SkeletonMecanim>().Initialize(true);
            if (isMoving)
                animator.SetTrigger("Move");
        }
        else
        {
            FindObjectOfType<Map>().ChangeSide(front, !right);
        }
    }

    //private void ChangeAnimator()
    //{
    //    SkeletonDataAsset asset = Resources.Load<SkeletonDataAsset>
    //        ($"{ReturnAssetPath.ReturnSpineAssetPath(character.characterArtCode, true)}");
    //    animator.GetComponent<SkeletonMecanim>().skeletonDataAsset = asset;
    //    string controllerPath = $"{ReturnAssetPath.ReturnSpineControllerPath(character.characterArtCode, true)}";
    //    //Debug.Log($"{ReturnAssetPath.ReturnSpineControllerPath(character.characterArtCode, true)}");
    //    animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(controllerPath);
    //    animator.GetComponent<SkeletonMecanim>().Initialize(true);
    //}
}
