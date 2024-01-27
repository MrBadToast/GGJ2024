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
        var half = spawnCount / 2;
        
        if (score < half)
            isGoodJob = false;
        else if (score >= half)
            isGoodJob = true;

        StartCoroutine(ReactionCo());
    }
    
    public IEnumerator ReactionCo()
    {
        // 1. 계산된 점수로 애니메이션 플레이
        if (isGoodJob)
        {
            
        }
        else
        {
            
        }

        yield return new WaitForSeconds(1f);
        
        UIManager.instance.resultWindow.Open();
    }
}
