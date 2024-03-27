using UnityEngine;
using Cinemachine;

public class CinemachineScreenShake : MonoBehaviour
{
    public CinemachineBrain cinemachineBrain;
    public SOShakeSettings shakeSettings;
    public CinemachineVirtualCamera virtualCamera => GetHighestPriorityVCam();
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    public NoiseSettings noiseSettings;

    public float shakeDuration = 0.5f;
    public float shakeAmplitude = 0.5f;  // The strength of the shake
    public float shakeFrequency = 2.0f;  // Speed of the shake

    private float shakeElapsedTime = 0f;

    void Start()
    {
        // Fetch the noise profile on the virtual camera
        if (virtualCamera != null)
        {
            virtualCameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            //if (virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>() == null)
            //{
            //    virtualCameraNoise = virtualCamera.AddCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            //    virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = noiseSettings;
            //}
        }
    }

    void Update()
    {
        if (virtualCameraNoise == null)
        {
            return;
        }
        // If there is noise profile present and time remaining on our shake
        if (virtualCameraNoise != null && shakeElapsedTime > 0)
        {
            // Set the amplitude and frequency based on the given values
            virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
            virtualCameraNoise.m_FrequencyGain = shakeFrequency;

            // Update the elapsed time
            shakeElapsedTime -= Time.deltaTime;
        }
        else
        {
            // Reset to no noise when the shake duration is over
            virtualCameraNoise.m_AmplitudeGain = 0;
            virtualCameraNoise.m_FrequencyGain = 0;
            shakeElapsedTime = 0;
        }
    }

    // Function to trigger shake
    public void TriggerShake()
    {
        shakeElapsedTime = shakeDuration;
    }
    public void TriggerShake(string shakeType)
    {
        var setting = shakeSettings.Load(shakeType);
        shakeDuration = setting.shakeDuration;
        shakeAmplitude = setting.shakeAmplitude;
        shakeFrequency = setting.shakeFrequency;
        TriggerShake();
    }
    CinemachineVirtualCamera GetHighestPriorityVCam()
    {
        int priority = 0;
        CinemachineVirtualCamera output = null;
        var list = FindObjectsOfType<CinemachineVirtualCamera>();
        foreach (var c in list)
        {
            if (c.Priority > priority)
            {
                output = c;
            }
        }
        return output;
    }
}
