using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetSlotShine : MonoBehaviour
{
    public string slotID;
    public string actionKeyToShine = "»ßÂ¸";
    public bool ShineOn = false;
    public bool SetOnEnable = false;
    public void OnEnable()
    {
        if (SetOnEnable)
        {
            SetShine();
        }
    }
    public void SetShine()
    {
        var target = FindObjectsOfType<PoliticSlot>(true).FirstOrDefault(x => x.slotID == slotID);
        if (ShineOn)
        {
            if (target.ShineObject == null)
            {
                var shineOrigin = Resources.Load<GameObject>("PoliticAnimation/ShineAnimations/Shine");
                target.ShineObject = Instantiate(shineOrigin, target.transform);
                target.ShineObject.transform.SetSiblingIndex(0);
            }
            var popup = target.GetComponentInChildren<PoliticPopup>();
            var group = popup.GetComponentsInChildren<Animator>().Where(x => x.runtimeAnimatorController.name == "ShineRed");
            foreach (var anim in group)
            {
                if (anim.gameObject.name == actionKeyToShine)
                {
                    anim.Play("Shine");
                }
            }
        }
        else
        {
            if (target.ShineObject != null)
            {
                var popup = target.GetComponentInChildren<PoliticPopup>();
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
                    Destroy(target.ShineObject);
                    target.ShineObject = null;
                }
            }
        }
    }
}
