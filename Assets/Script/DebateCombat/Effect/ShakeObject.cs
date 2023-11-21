using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    // Initial position of the object
    private Vector3 initialPosition;

    // Variables for the shaking effect
    public float shakeDuration = 1.0f;    // Duration of the shake in seconds
    public float shakeIntensity = 0.1f;   // Intensity of the shake

    private float shakeTimer = 0f;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            // Generate random offsets for the shake effect
            float offsetX = Random.Range(-1f, 1f) * shakeIntensity;
            float offsetY = Random.Range(-1f, 1f) * shakeIntensity;

            // Apply the shake effect to the object's position
            transform.localPosition = initialPosition + new Vector3(offsetX, offsetY, 0);

            // Decrement the timer
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset the object's position when the shake duration is over
            transform.localPosition = initialPosition;
        }
    }

    // Trigger the shake effect
    public void StartShake()
    {
        shakeTimer = shakeDuration;
    }
}