using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DirectScreenShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float shakeIntensity = 0.5f;
    public float shakeDuration = 0.5f;

    private Vector3 originalCameraPosition;
    private float shakeElapsedTime = 0f;

    private void Start()
    {
        originalCameraPosition = virtualCamera.Follow.position;
    }

    private void Update()
    {
        if (shakeElapsedTime > 0)
        {
            virtualCamera.Follow.position = originalCameraPosition + Random.insideUnitSphere * shakeIntensity;
            shakeElapsedTime -= Time.deltaTime;
        }
        else
        {
            virtualCamera.Follow.position = originalCameraPosition;
            shakeElapsedTime = 0;
        }
    }

    public void ShakeCamera()
    {
        shakeElapsedTime = shakeDuration;
    }
}
