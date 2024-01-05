using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateHolderAnimationPlayer : MonoBehaviour
{
    public List<GateHolderAnimation> animations = new List<GateHolderAnimation>();
    public GateHolderAnimation animationPref = null;
    public List<RectTransform> pages = new List<RectTransform>();
    public List<float> Yvalues = new List<float>();
    public float rollDuration = 1f;
    public float animationDuration = 0.5f;
    public RectTransform page = null;
    public IEnumerator StartAnimationSequence()
    {
        animations.RemoveAll(x => x == null);
        for (int i = 0; i < Yvalues.Count; i++)
        {
            var playList = FindAnimationInLevel(i);
            if (playList.Count > 0)
            {
                RollTo(i);
                yield return new WaitForSeconds(rollDuration);
                foreach (var play in playList)
                {
                    play.transform.position = play.slot.transform.position;
                    play.ObjectToOpen.gameObject.SetActive(true);
                    page.GetComponent<ShakeObject>().StartShake();
                    yield return new WaitForSeconds(animationDuration / 2);
                    Destroy(play.slot.GateHolder.gameObject);
                    yield return new WaitForSeconds(animationDuration / 2);
                    play.slot.EmptySlotModeSetup();
                }
                yield return new WaitForSeconds(1f);
            }
        }
        foreach (var play in animations)
        {
            Destroy(play.gameObject);
        }
    }
    private void Start()
    {
        //StartSequence();
    }
    public void StartSequence()
    {
        StartCoroutine(StartAnimationSequence());
    }
    public List<GateHolderAnimation> FindAnimationInLevel(int level)
    {
        var output = new List<GateHolderAnimation>();
        foreach (GateHolderAnimation anim in animations)
        {
            if (anim.slot.Level == level)
                output.Add(anim);
        }
        return output;
    }
    public void RollTo(int level)
    {
        float y = Yvalues[level];
        page.GetComponent<RectTransform>().DOAnchorPosY(y, rollDuration);
        //.OnComplete(() => { transform.position = animation.slot.transform.position; animation.Elim.gameObject.SetActive(true); })
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
        player.animations.Add(newAnim);
    }

}
