using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class AudioManager : MonoBehaviour
{
    public AudioSource menuMusic, mainGameMusic, guestLaughMusic;
    public AudioSource[] miniGameMusic;
    public AudioSource[] allSFX;

    public void StopMusic()
    {
        menuMusic.Stop();
        mainGameMusic.Stop();
        guestLaughMusic.Stop();
        
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
}
