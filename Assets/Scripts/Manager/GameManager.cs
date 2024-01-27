using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() => instance = this;

    public GameConfig gameConfig; 
    public Level startLevel;
    public string lastSceneName;
    
    void SetStartData()
    {
        StageController.instance.curLevel = gameConfig.StartLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        // 0. 현재 데이터에 해당하는 
        SetStartData();
        StartCoroutine(BeforeGameStartCo());
    }

    IEnumerator BeforeGameStartCo()
    {
        // 1. 게임 시작전 시작을 알리는 애니메이션 ㄱㄱ
        Debug.Log("BeforeGameStartCo");
        
        yield return null;
        
        StageController.instance.StartStage();
    }

   
}
