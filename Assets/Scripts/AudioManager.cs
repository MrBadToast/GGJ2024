using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            SetupAudioManager();
        else if (instance != this)
            Destroy(gameObject);
    }

    public void SetupAudioManager()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public AudioSource menuMusic, mainGameMusic;
    public AudioSource[] miniGameMusic;
    public AudioSource[] guestPositiveSounds;
    public AudioSource[] guestNegativeSounds;
    public AudioSource[] allSFX;

    public void StopMusic()
    {
        menuMusic.Stop();
        mainGameMusic.Stop();
        
        foreach (var audio in miniGameMusic)
            audio.Stop();
        
        foreach (var audio in allSFX)
            audio.Stop();
    }

    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }

    public void PlayMainGameMusic()
    {
        StopMusic();
        mainGameMusic.Play();
    }

    public void SetVolumeMainGameMusic(float volume)
    {
        mainGameMusic.volume = volume;
    }
    
    public void PlaySFX(int index)
    {
        allSFX[index].Stop();
        allSFX[index].Play();
    }

    public void PlayRandomMiniGameMusic()
    {
        foreach (var audio in miniGameMusic)
            audio.Stop();

        var index = Random.Range(0, miniGameMusic.Length - 1);
        miniGameMusic[index].Play();
    }

    public void PlayRandomGuestPositiveSound()
    {
        foreach (var sound in guestPositiveSounds)
            sound.Stop();

        guestPositiveSounds[Random.Range(0, guestPositiveSounds.Length - 1)].Play();
    }

    public void PlayRandomGuestNegativeSound()
    {
        foreach (var sound in guestNegativeSounds)
            sound.Stop();

        guestNegativeSounds[Random.Range(0, guestNegativeSounds.Length - 1)].Play();
    }
}
