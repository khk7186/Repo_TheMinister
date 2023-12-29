using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateHolderAnimation : MonoBehaviour
{
    public PoliticSlot slot;
    public GameObject ObjectToOpen = null;
    public bool isElim = false;
    public GameObject Elim;

    public void SetElim()
    {
        isElim = true;
        ObjectToOpen = Elim;
    }
    public void Set(PoliticSlot slot)
    {
        this.slot = slot;
    }


}
