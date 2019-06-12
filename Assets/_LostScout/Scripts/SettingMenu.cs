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

    private void Start()
    {
        int final = (40 * 100) / 60;
        txtMasterVolume.text = final + "%";
        txtMusicVolume.text = final + "%";
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
}
