using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookAtMainCharacter : MonoBehaviour
{
    private void OnEnable()
    {
        var VC = GetComponent<CinemachineVirtualCamera>();
        VC.Follow = GameObject.FindObjectOfType<Player>().transform;
    }
}
