using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCardInCombat : MonoBehaviour
{
    CombatSceneController csc;
    CombatCharacterUnit thisUnit;
    private void Awake()
    {
        csc = FindObjectOfType<CombatSceneController>();
        thisUnit = GetComponent<CombatCharacterUnit>();
    }
    private void OnEnable()
    {
        
    }
    public void OnMouseEnter()
    {
        //CombatSceneController.CameraFocus(true);
        bool show = false;
        if (thisUnit == null)
        {
            thisUnit = GetComponent<CombatCharacterUnit>();
        }
        if (csc == null)
        {
            csc = FindObjectOfType<CombatSceneController>();
        }
        show = !csc.OnAction
                    || csc.CurrentOnActionCCU?.currentAction == Action.Defence && thisUnit.IsFriend
                    || csc.CurrentOnActionCCU?.currentAction != Action.Defence && !thisUnit.IsFriend;
        if (show)
        {
            CombatSceneController.ShowCard(thisUnit);
        }
    }
    public void OnMouseExit()
    {
        //StartCoroutine(OriginCamera());
    }

    IEnumerator OriginCamera()
    {
        yield return new WaitForEndOfFrame();
        CombatSceneController.CameraFocus(false);
        CombatSceneController.MoveCamera(0);
    }
}
