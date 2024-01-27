using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestController : MonoBehaviour
{
    public static GuestController instance;
    private void Awake() => instance = this;
    public CrowdsAnimationControl crowdAnim;
    public AudioSource audioSource;
    public AudioClip badumTss;

    public bool isGoodJob;
    
    public void AudienceReaction(int score, int spawnCount)
    {
        // 패턴 맞춘 것에 대한 연산
        var half = spawnCount / 2f;
        
        if (score < half)
            isGoodJob = false;
        else if (score >= half)
            isGoodJob = true;

        StartCoroutine(ReactionCo());
    }
    
    public IEnumerator ReactionCo()
    {
        audioSource.PlayOneShot(badumTss);

        yield return new WaitForSeconds(1.5f);
        
        if (isGoodJob)
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.SetVolumeMainGameMusic(.35f);
                AudioManager.instance.PlayRandomGuestPositiveSound();
                crowdAnim.SetSpeed(1.5f);
            }
        }
        else
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.SetVolumeMainGameMusic(.35f);
                AudioManager.instance.PlayRandomGuestNegativeSound();
                crowdAnim.PauseAll();
            }
        }

        yield return new WaitForSeconds(3f);

        crowdAnim.PlayAll();
        crowdAnim.SetSpeed(1.0f);
        AudioManager.instance.SetVolumeMainGameMusic(.7f);
        UIManager.instance.resultWindow.Open();

        isGoodJob = false;
        TimingManager.instance.score = 0;
    }
}
