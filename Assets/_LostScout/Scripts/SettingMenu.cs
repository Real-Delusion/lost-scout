using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public Text txtMasterVolume;
    public Text txtMusicVolume;
    public Dropdown resolutionDropDown;
    public Dropdown graphiscsDropDown;

    Resolution[] resolutions;

    private void Start()
    {
        int final = (40 * 100) / 60;
        txtMasterVolume.text = final + "%";
        txtMusicVolume.text = final + "%";

        //Graphics
        graphiscsDropDown.value = QualitySettings.GetQualityLevel();

        //Resolutions
        initialResolution();
        
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMasterVolume (float volume)
    {
        mixer.SetFloat("MasterVolume", volume) ;
        int primitivo = ((int)volume + 40);
        int final = (primitivo * 100) / 60;
        txtMasterVolume.text = final + "%";
    }

    public void SetMusicVolume (float volume)
    {
        mixer.SetFloat("MusicVolume", volume) ;
        int primitivo = ((int)volume + 40);
        int final = (primitivo * 100) / 60;
        txtMusicVolume.text = final + "%";
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if(isFullScreen) resolutionDropDown.interactable = true;
        else resolutionDropDown.interactable = false;
    }

    public void initialResolution()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

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

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }
}
