using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{
    public AudioClip sound;
    AudioMixer mixer;
    private Button button { get {
        return GetComponent<Button>();
    }}
    private AudioSource source { get {
        return GetComponent<AudioSource>();
    }}
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        mixer = Resources.Load("AudioMixer") as AudioMixer;
        // Any other settings
        source.outputAudioMixerGroup = mixer.FindMatchingGroups("UI")[0];

        button.onClick.AddListener(()=> PlaySound());
    }

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }
}
