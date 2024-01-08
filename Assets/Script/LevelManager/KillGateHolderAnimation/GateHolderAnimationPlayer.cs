using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Spine;
using TMPro;

public class GateHolderAnimationPlayer : MonoBehaviour
{
    public List<GateHolderAnimation> animations = new List<GateHolderAnimation>();
    public GateHolderAnimation animationPref = null;
    public List<RectTransform> pages = new List<RectTransform>();
    public List<float> Yvalues = new List<float>();
    public float rollDuration = 1f;
    public GateHolderAnimation currentAnimation = null;
    public float animationDuration = 0.5f;
    public RectTransform page = null;
    public IEnumerator StartAnimationSequence()
    {
        int level = currentAnimation.slot.Level;
        Debug.Log(level);

        yield return StartCoroutine(RollTo(level));
        currentAnimation.transform.parent = currentAnimation.slot.transform;
        yield return new WaitForSeconds(0.5f);
        currentAnimation.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        currentAnimation.ObjectToOpen.gameObject.SetActive(true);
        page.GetComponent<ShakeObject>().StartShake();
        yield return new WaitForSeconds(animationDuration / 2);
        Destroy(currentAnimation.slot.GateHolder.gameObject);
        yield return new WaitForSeconds(animationDuration / 2);
        currentAnimation.ObjectToOpen.gameObject.SetActive(false);
        currentAnimation.slot.EmptySlotModeSetup();
        Destroy(currentAnimation.gameObject);
        currentAnimation = null;
    }
    private void Start()
    {
        //StartSequence();
    }
    public void StartSequence()
    {
        StartCoroutine(StartAnimationSequence());
    }
    //public List<GateHolderAnimation> FindAnimationInLevel(int level)
    //{
    //    var output = new List<GateHolderAnimation>();
    //    foreach (GateHolderAnimation anim in animations)
    //    {
    //        if (anim.slot.Level == level)
    //            output.Add(anim);
    //    }
    //    return output;
    //}
    public IEnumerator RollTo(int level)
    {
        float y = Yvalues[level];
        var rect = page.GetComponent<RectTransform>();
        var startPosition = rect.anchoredPosition;
        var targetPosition = new Vector2(startPosition.x, y);
        //.OnComplete(() => { transform.position = animation.slot.transform.position; animation.Elim.gameObject.SetActive(true); })
        float elapsedTime = 0;
        while (elapsedTime < rollDuration)
        {
            float t = elapsedTime / rollDuration;
            if (t > 1) t = 1;
            rect.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    public static void AddAnimation(bool Elim, PoliticSlot slot)
    {
        var player = FindObjectOfType<GateHolderAnimationPlayer>();
        if (player == null) return;

        var newAnim = (Instantiate(player.animationPref, player.transform));
        if (Elim)
        {
            newAnim.Set(slot);
            newAnim.SetElim();
        }
        player.currentAnimation = newAnim;
    }

}
