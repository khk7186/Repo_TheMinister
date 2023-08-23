using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ShakeSettings", menuName = "Shake Settings", order = 0)]
public class SOShakeSettings : ScriptableObject
{
    public List<ShakeSettings> shakeSettings;
    public ShakeSettings Load(string name)
    {
        return shakeSettings.FirstOrDefault(x => x.Name == name);
    }
}
[Serializable]
public class ShakeSettings
{
    public string Name;
    public float shakeDuration = 0.5f;
    public float shakeAmplitude = 1.0f;
    public float shakeFrequency = 2.0f;
}
