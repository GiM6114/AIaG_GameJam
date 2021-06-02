using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class MusicManager : MonoBehaviour
{
    [SerializeField] SoundManager sM;
    public void SwitchMusic(string to)
    {
        Sound s = Array.Find(sM.sounds, sound => sound.name == to);
        // cas ou une demande de musique arrive mais il y a déjà la musique
        if (s.source.isPlaying && s.source.volume == 1)
        {
            return;
        }
        //StartCoroutine(StartFade(to));
    }
    /*
    public static IEnumerator StartFade(string to)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }*/
}
