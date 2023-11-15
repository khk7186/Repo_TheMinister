using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    public bool flipOnEnable = false;
    public bool disableAfterFlip = false;
    public bool flipMain = false;
    public SideChanger sideChanger;
    public bool front = false;
    public bool right = false;

    private void OnEnable()
    {
        if (flipOnEnable)
        {
            Flip();
            if (disableAfterFlip)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void Flip()
    {
        if (flipMain)
        {
            sideChanger = FindObjectOfType<Player>().GetComponent<SideChanger>();
        }
        sideChanger.ChangeSideViaData(front, right);
    }
}
