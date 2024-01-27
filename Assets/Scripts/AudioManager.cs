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
    public AudioSource[] robotLaughs;
    public AudioSource[] guestSounds;
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

    public void PlayGuestLaughMusic()
    {
        StopMusic();
        mainGameMusic.Play();
    }
    
    public void PlaySFX(int index)
    {
        allSFX[index].Stop();
        allSFX[index].Play();
    }
    
    public void PlayRandomPitchedSFX(int index, float pitch, bool random = false)
    {
        allSFX[index].Stop();
        allSFX[index].pitch = random ? Random.Range(0.25f, 1.75f) : pitch;
        allSFX[index].Play();
    }

    public void PlayRandomMiniGameMusic()
    {
        foreach (var audio in miniGameMusic)
            audio.Stop();

        var index = Random.Range(0, miniGameMusic.Length - 1);
        miniGameMusic[index].Play();
    }

    public void PlayGuestSounds(int index)
    {
        foreach (var audio in guestSounds)
            audio.Stop();

        guestSounds[index].Play();
    }
}
