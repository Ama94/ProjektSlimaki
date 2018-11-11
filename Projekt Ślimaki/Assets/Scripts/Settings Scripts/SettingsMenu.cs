using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    float volume;

	// Use this for initialization
	void Start ()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        audioMixer.GetFloat("volume",out volume);
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
    
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }


        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        this.volume = volume;

        //TODO zmiana Volumetoggle

    }

    public void SetVolumeOnOff(bool isOn)
    {
        if (isOn)
        {
            audioMixer.SetFloat("volume", this.volume);
        }
        else
        {
            audioMixer.SetFloat("volume", 0);
        }
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }
}
