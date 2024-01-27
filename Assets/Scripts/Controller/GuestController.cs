using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestController : MonoBehaviour
{
    public static GuestController instance;
    private void Awake() => instance = this;

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
        // 1. 계산된 점수로 애니메이션 플레이

        yield return new WaitForSeconds(2.5f);
        
        if (isGoodJob)
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.SetVolumeMainGameMusic(.35f);
                AudioManager.instance.PlayRandomGuestPositiveSound();
            }
        }
        else
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.SetVolumeMainGameMusic(.35f);
                AudioManager.instance.PlayRandomGuestNegativeSound();
            }
        }

        yield return new WaitForSeconds(3f);
        
        AudioManager.instance.SetVolumeMainGameMusic(.7f);
        UIManager.instance.resultWindow.Open();

        isGoodJob = false;
        TimingManager.instance.score = 0;
    }
}
