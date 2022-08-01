using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SideChanger : MonoBehaviour
{
    public Animator animator;
    public SkeletonMecanim skeletonMecanim;
    public Vector2 oldPosition;
    public Vector2 PosDif;
    public bool isRight;
    public bool isFront;
    private void Awake()
    {
        oldPosition = (Vector2)transform.position;
    }
    public void FixedUpdate()
    {
        if ((Vector2)transform.position != oldPosition)
        {
            PosDif = (Vector2)transform.position - oldPosition;
            bool right = transform.position.x - oldPosition.x > 0;
            bool front = transform.position.y - oldPosition.y < 0;
            if (right != isRight || front != isFront)
            {
                isRight = right;
                isFront = front;
                changeSide(isFront, isRight);
            }
        }
        oldPosition = transform.position;
    }
    public void changeSide(bool front, bool right)
    {
        if (TryGetComponent<DefaultInGameAI>(out var inGameAI))
        {
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
