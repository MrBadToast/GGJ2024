using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestController : MonoBehaviour
{
    public static GuestController instance;
    private void Awake() => instance = this;

    public void AudienceReaction()
    {
        StartCoroutine(ReactionCo());
    }
    
    public IEnumerator ReactionCo()
    {
        // 1. 미니게임 패턴 맞춘 수에 따라서 점수 계산
        CalculateBonusPoint();
        
        // 2. 계산된 점수로 애니메이션 플레이
        React();
        yield return new WaitForSeconds(1f);
    }

    public void CalculateBonusPoint()
    {
        // 패턴 맞춘 것에 대한 연산
    }
    
    public void React()
    {
        // 애니메이션 플레이
    }
}
