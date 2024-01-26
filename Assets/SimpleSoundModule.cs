// ====================================
//
// Simple soundmodule for Unity
// v 1.1
//
// Public domiain dedication
// Copy or modify, commercial use are available for your project freely.
//
// Features : Easliy Play / Stop / Play Random pitch, volume or soundclips / FadeIn-Out
// 
// Notice! Only single sound could be played at once. When you play some sound while other one is playing, later one will override previous one.
// If you want to make more than two sound at once, Create enough number of Gameobjects and then apply a soundmodule each of them.
// Directly setting pitch or volume by AudioSource is not recommended.
//
// ship2042@gmail.com / @BOREALIS_FINCH (SIR_BAD_TOAST)
//
// ====================================

using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class SimpleSoundModule : MonoBehaviour
{
    [SerializeField] private SoundItem[] soundItems;
    public SoundItem[] SoundItems { get => soundItems; }

    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    public void Play(string soundName)
    {
        try
        {
            var cur = SoundItem.GetSoundItem(soundItems, soundName);

            aud.clip = cur.audioClips[Random.Range(0, cur.audioClips.Length)];

            if (cur.randomPitch)
                aud.pitch = Random.Range(cur.pitchMin, cur.pitchMax);
            else
                aud.pitch = 1.0f;

            if (cur.randomVolume)
                aud.volume = Random.Range(cur.volumeMin, cur.volumeMax);
            else
                aud.volume = 1.0f;

            aud.Play();
        }
#pragma warning disable CS0168
        catch (NullReferenceException n)
        {
            Debug.LogError("SimpleSoundModule : Cannot found soundname \"" + soundName + "\" in Object \"" + gameObject.name + "\"" );
        }
        catch(IndexOutOfRangeException i)
        {
            Debug.LogError("SimpleSoundModule : soundname \"" + soundName + "\" in Object \"" + gameObject.name + "\" : Audio is Empty!");
        }
#pragma warning restore CS0168
    }

    public void Stop()
    {
        aud.Stop();
    }

    public void FadeIn(string soundName, float time)
    {
        StopAllCoroutines();
        Play(soundName);
        StartCoroutine(Cor_FadeIn(aud.volume,time));
    }

    public void FadeOut(float time)
    {
        if (aud.volume == 0f) return;

        StopAllCoroutines();
        StartCoroutine(Cor_FadeOut(aud.volume, time));
    }

    private IEnumerator Cor_FadeIn(float maxVol,float time)
    {
        aud.volume = 0f;
        for(float i = 0; i < 1; i += Time.deltaTime/time)
        {
            aud.volume = i * maxVol;
            yield return null;
        }

        aud.volume = maxVol;
    }

    private IEnumerator Cor_FadeOut(float currentVol, float time)
    {
        for(float i = 1; i > 0; i -= Time.deltaTime/time)
        {
            aud.volume = i*currentVol;
            yield return null;
        }
        aud.volume = 0f;
    }
}

[Serializable]
public class SoundItem
{
    public string name;
    public AudioClip[] audioClips;

    public bool randomPitch;
    [Range(-3f,3f)]
    public float pitchMin = 1.0f;
    [Range(-3f,3f)]
    public float pitchMax = 1.0f;

    public bool randomVolume;
    [Range(0f, 1f)]
    public float volumeMin = 1.0f;
    [Range(0f, 1f)]
    public float volumeMax = 1.0f;

    public static SoundItem GetSoundItem(SoundItem[] soundItems, string key)
    {
        return Array.Find(soundItems, i => i.name == key);      
    }
}