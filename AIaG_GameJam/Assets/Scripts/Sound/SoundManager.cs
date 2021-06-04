using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioMixerGroup musicMixer;
    [SerializeField] AudioMixerGroup SFXMixer;
    [SerializeField] bool doesMusic;

    public Sound[] sounds;

    AudioSource currentMusicSource;

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
            s.source.loop = !s.isSFX;
            s.source.playOnAwake = false;
        }
        if (!doesMusic) return;
        currentMusicSource = Array.Find(sounds, sound => sound.name == "InDoorMusic").source;
        currentMusicSource.Play();
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void SwitchMusic(string to)
    {
        Sound m = Array.Find(sounds, sound => sound.name == to);
        if(m == null || m.source == null)
        {
            return;
        }
        // cas ou une demande de musique arrive mais il y a déjà la musique
        if (m.source.isPlaying && m.source.volume == 1)
        {
            return;
        }
        StartCoroutine(StartFade(m.source,2f));
    }


    public IEnumerator StartFade(AudioSource to, float duration)
    {
        // FADE OUT
        float currentTime = 0;
        float start = currentMusicSource.volume;

        while (currentTime < duration/2)
        {
            currentTime += Time.deltaTime;
            currentMusicSource.volume = Mathf.Lerp(1, 0, currentTime / (duration /2));
            yield return null;
        }

        // FADE IN
        currentTime = 0;
        start = to.volume;

        while (currentTime < duration / 2)
        {
            currentTime += Time.deltaTime;
            to.volume = Mathf.Lerp(0, 1, currentTime / (duration / 2));
            yield return null;
        }

        currentMusicSource.Stop();
        currentMusicSource = to;
        currentMusicSource.Play();

    }

}
