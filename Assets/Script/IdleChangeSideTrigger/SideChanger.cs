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
    private float duration = 0.1f;
    public bool isRight;
    public bool isFront;
    public bool CutScene = false;
    public CharacterArtCode characterArtCode;
    public CharacterModelController model;
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
        if (model == null)
        {
            StartCoroutine(changeSideAnimation(front, right));
        }
        else
        {
            StartCoroutine(changeModelSideAnimation(front, right));
        }
    }
    IEnumerator changeModelSideAnimation(bool front, bool right)
    {
        float time = 0;
        Vector3 start = model.front.gameObject.transform.localScale;
        Vector3 target = new Vector3((right ? -0.7f : 0.7f), start.y, start.z);
        SkeletonMecanim targetSkeleton = front ? model.front : model.back;
        while (time < duration)
        {
            time += Time.deltaTime;
            model.current.gameObject.transform.localScale = Vector3.Lerp(start, new Vector3(0, start.y), time / duration);
            yield return null;
        }
        if (front)
        {
            model.SetFront();
        }
        else
        {
            model.SetBack();
        }
        while (time < duration)
        {
            time += Time.deltaTime;
            targetSkeleton.gameObject.transform.localScale = Vector3.Lerp(new Vector3(0, start.y), target, time / duration);
            yield return null;
        }
    }
    IEnumerator changeSideAnimation(bool front, bool right)
    {
        float time = 0;
        Vector3 start = animator.gameObject.transform.localScale;
        Vector3 target = animator.gameObject.transform.localScale;
        target = new Vector3((right ? -0.7f : 0.7f), target.y, target.z);
        while (time < duration)
        {
            time += Time.deltaTime;
            animator.gameObject.transform.localScale = Vector3.Lerp(start, new Vector3(0, start.y), time / duration);
            yield return null;
        }
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


            animator.transform.localScale = target;
            animator.GetComponent<SkeletonMecanim>().Initialize(true);
        }
        else if (CutScene)
        {
            string side = front ? "Front" : "Back";
            SkeletonDataAsset asset = Resources.Load<SkeletonDataAsset>
            ($"{ReturnAssetPath.ReturnSpineAssetPath(characterArtCode, front)}");
            animator.GetComponent<SkeletonMecanim>().skeletonDataAsset = asset;
            string controllerPath = $"{ReturnAssetPath.ReturnSpineControllerPath(characterArtCode, true)}";
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(controllerPath);
            animator.GetComponent<SkeletonMecanim>().Initialize(true);

            animator.transform.localScale = target;
            animator.GetComponent<SkeletonMecanim>().Initialize(true);
        }
        else
        {
            FindObjectOfType<Map>(true).ChangeSide(front, !right);
        }
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(ReturnAssetPath.ReturnSpineControllerPath(characterArtCode, front));
        time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            animator.gameObject.transform.localScale = Vector3.Lerp(new Vector3(0, start.y), target, time / duration);
            yield return null;
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
