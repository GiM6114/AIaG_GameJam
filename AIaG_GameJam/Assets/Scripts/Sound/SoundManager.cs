using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioMixerGroup musicMixer;
    [SerializeField] AudioMixerGroup SFXMixer;

    public Sound[] sounds;
    AudioSource aS;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            AudioSource aS = gameObject.AddComponent<AudioSource>();
            aS.outputAudioMixerGroup = s.isSFX ? SFXMixer : musicMixer;
            s.source = aS;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
