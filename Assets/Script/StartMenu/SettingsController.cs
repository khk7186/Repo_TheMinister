using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
public class SettingsController : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider masterVolumeSlider;
    public Slider brightnessSlider;

    public AudioMixer mainMixer;

    public Dropdown resolutionDropdown;
    public Dropdown displayModeDropdown;
    private List<Resolution> resolutions = new List<Resolution>
    {
        new Resolution { width = 1920, height = 1080 },
        new Resolution { width = 2560, height = 1440 },
        new Resolution { width = 3840, height = 2160 }
    };

    private void Start()
    {
        resolutions = new List<Resolution>
            {
                new Resolution { width = 1920, height = 1080 },
                new Resolution { width = 2560, height = 1440 },
                new Resolution { width = 3840, height = 2160 }
            };
        // You can load saved settings here, if any

        // Add listeners to sliders
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);

        SetupResolutionDropdown();
        displayModeDropdown.AddOptions(new List<string> { "ȫ��", "����" });
        displayModeDropdown.onValueChanged.AddListener(SetDisplayMode);
    }
    public void SetMasterVolume(float volume)
    {
        if (volume == 0)
            mainMixer.SetFloat("MasterVolume", -80);
        else
            mainMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        if (volume == 0)
            mainMixer.SetFloat("MusicVolume", -80);
        else
            mainMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        if (volume == 0)
            mainMixer.SetFloat("SFXVolume", -80);
        else
            mainMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }


    public void SetBrightness(float brightness)
    {
        RenderSettings.ambientLight = Color.white * brightness;
        // You might want to adjust other settings for more noticeable brightness changes
    }

    private void SetupResolutionDropdown()
    {
        resolutions = new List<Resolution>(Screen.resolutions);
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetDisplayMode(int modeIndex)
    {
        Screen.fullScreen = (modeIndex == 0) ? true : false;
    }
}
