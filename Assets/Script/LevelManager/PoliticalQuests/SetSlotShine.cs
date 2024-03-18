using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetSlotShine : MonoBehaviour
{
    public string slotID;
    public string slotName;
    public string actionKeyToShine = "»ßÂ¸";
    public bool ShineOn = false;
    public bool SetOnEnable = false;
    public bool UseSlotName = false;
    public void OnEnable()
    {
        if (SetOnEnable)
        {
            SetShine();
        }
    }
    public void SetOnSlot(PoliticSlot politicSlot)
    {
        if (politicSlot.ShineObject == null)
        {
            var shineOrigin = Resources.Load<GameObject>("PoliticAnimation/ShineAnimations/Shine");
            politicSlot.ShineObject = Instantiate(shineOrigin, politicSlot.transform);
            politicSlot.ShineObject.transform.SetSiblingIndex(0);
        }
        var popup = politicSlot.GetComponentInChildren<PoliticPopup>();
        var group = popup.GetComponentsInChildren<Animator>().Where(x => x.runtimeAnimatorController.name == "ShineRed");
        foreach (var anim in group)
        {
            if (anim.gameObject.name == actionKeyToShine)
            {
                anim.Play("Shine");
            }
        }
    }
    public void SetOffSlot(PoliticSlot politicSlot)
    {
        if (politicSlot.ShineObject != null)
        {
            var popup = politicSlot.GetComponentInChildren<PoliticPopup>();
            var group = popup.GetComponentsInChildren<Animator>().Where(x => x.runtimeAnimatorController.name == "ShineRed");
            bool stillActive = false;
            foreach (var anim in group)
            {
                if (anim.gameObject.name == actionKeyToShine)
                {
                    anim.Play("NoShine");
                }
                else
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Shine"))
                    {
                        stillActive = true;
                    }
                }
            }
            if (stillActive == false)
            {
                Destroy(politicSlot.ShineObject);
                politicSlot.ShineObject = null;
            }
        }
    }
    public void SetShine()
    {
        var target = FindObjectsOfType<PoliticSlot>(true).FirstOrDefault(x => x.slotID == slotID);
        if (ShineOn)
        {
            if (UseSlotName)
            {
                var listTarget = FindObjectsOfType<PoliticSlot>(true).Where(x => x.slotName == slotName);
                foreach (var slot in listTarget)
                {
                    SetOnSlot(slot);
                }
            }
            else
            {
                SetOnSlot(target);
            }
        }
        else
        {
            if (UseSlotName)
            {
                var listTarget = FindObjectsOfType<PoliticSlot>(true).Where(x => x.slotName == slotName);
                foreach (var slot in listTarget)
                {
                    SetOffSlot(slot);
                }
            }
            else
            {
                SetOffSlot(target);
            }
            //if (target.ShineObject != null)
            //{
            //    var popup = target.GetComponentInChildren<PoliticPopup>();
            //    var group = popup.GetComponentsInChildren<Animator>().Where(x => x.runtimeAnimatorController.name == "ShineRed");
            //    bool stillActive = false;
            //    foreach (var anim in group)
            //    {
            //        if (anim.gameObject.name == actionKeyToShine)
            //        {
            //            anim.Play("NoShine");
            //        }
            //        else
            //        {
            //            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Shine"))
            //            {
            //                stillActive = true;
            //            }
            //        }
            //    }
            //    if (stillActive == false)
            //    {
            //        Destroy(target.ShineObject);
            //        target.ShineObject = null;
            //    }
            //}
        }
    }
}
