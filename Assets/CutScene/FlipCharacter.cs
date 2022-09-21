using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    public bool flipOnEnable = false;
    public bool flipMain = false;
    public SideChanger sideChanger;
    public bool front = false;
    public bool right = false;

    private void OnEnable()
    {
        if (flipOnEnable)
        {
            Flip();
        }
    }
    public void Flip()
    {
        if (flipMain)
        {
            sideChanger = FindObjectOfType<Player>().GetComponent<SideChanger>();
        }
        sideChanger.changeSide(front, right);
    }
}
