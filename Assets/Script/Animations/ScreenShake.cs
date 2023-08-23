using UnityEngine;
using System.Collections;
public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.5f;
    public float dampingSpeed = 1.0f;

    private Vector3 initialPosition;
    private bool isShaking = false;
    public void TriggerShake()
    {
        isShaking = true;
        shakeDuration = 0.5f;
    }
    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (isShaking)
        {
            if (shakeDuration > 0)
            {
                transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
                shakeDuration -= Time.deltaTime * dampingSpeed;
            }
            else
            {
                isShaking = false;
                shakeDuration = 0f;
                transform.localPosition = initialPosition;
            }
        }
    }


}
