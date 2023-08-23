using PixelCrushers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class CombatSelectUIController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CombatCharacterUnit Target;
    public CombatSelectUI ccu => GetComponent<CombatSelectUI>();
    public bool onCCU = false;
    public bool onUI = false;
    public Animator UIAnimator;
    public static bool SHOWING = false;
    private void Awake()
    {
        SHOWING = false;
        gameObject.SetActive(false);
    }

    public static void Show(CombatCharacterUnit target)
    {
        var csc = FindObjectOfType<CombatSceneController>();
        if (csc.OnAction == true) return;
        var ui = GameObject.FindObjectOfType<CombatSelectUIController>(true);
        if (ui.gameObject.activeSelf == false) ui.gameObject.SetActive(true);
        ui.onCCU = true;
        if (ui.Target != target)
        {
            ui.Target = target;
            ui.ccu.unit = target;
            ui.ccu.Setup(target.transform);
        }
        //if (ui.UIAnimator.GetBool("Show") == true)
        //{
        //    ui.UIAnimator.Play("Show", 0, 0f);
        //}
        //else
        //{
        //}
        ui.UIAnimator.Play("Show", -1, 0f);
        ui.UIAnimator.SetBool("Show", true);
        SHOWING = true;
    }


    public static void Hide(bool fromCCU = true)
    {
        var ui = GameObject.FindObjectOfType<CombatSelectUIController>(true);
        if (fromCCU)
        {
            ui.onCCU = false;
        }
        else
        {
            ui.onUI = false;
        }

        if (ui.onUI == false && ui.onCCU == false)
        {
            ui.UIAnimator.SetBool("Show", false);
            SHOWING = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onUI = true;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        Hide(false);
    }
}
