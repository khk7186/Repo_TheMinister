using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerCameraController : MonoBehaviour
{
    GameEventManager gameEventManager => GameEventManager.Instance;
    CinemachineVirtualCamera virtualCamera
    {
        get
        {
            CinemachineVirtualCamera vc = FindObjectOfType<Player>()?.GetComponentInChildren<CinemachineVirtualCamera>();
            if (vc != null) return vc;
            return null;
        }
    }

    //private void OnEnable()
    //{
    //    TurnOff();
    //}
    IEnumerator RestartCamera()
    {
        Func<bool> restart = () => gameEventManager.currentEvent == null;
        yield return new WaitUntil(restart);
    }

    private void TurnOff()
    {
        if (gameEventManager.currentEvent != null)
        {
            virtualCamera.gameObject.SetActive(false);
            StartCoroutine(RestartCamera());
        }
    }
}
