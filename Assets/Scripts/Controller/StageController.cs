using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public static StageController instance;
    private void Awake() => instance = this;

    public Level curLevel;
    public GameConfig.StageLevelData CurStageLevelData;
    public int curPoint;
    
    public void LoadData()
    {
        Debug.Log("StageController.LoadData");
        foreach (var gameConfigStageLevelData in GameManager.instance.gameConfig.StageLevelDatas)
        {
            if (curLevel == gameConfigStageLevelData.Name)
                CurStageLevelData = gameConfigStageLevelData;
        }
    }

    public void StartStage()
    {
        LoadData();
        // 4. ComedySelectWindow 오픈
        UIManager.instance.comedySelectWindow.Open(CurStageLevelData);
    }

    public void NextLevel()
    {
        //curPoint = 0;
        ++curLevel;

        if (GameManager.instance.gameConfig.StageLevelDatas.Length <= (int)curLevel)
        {
            SceneManager.LoadScene(GameManager.instance.lastSceneName);
        }
        else
        {
            LoadData();
            StartStage();
        }
    }

    public void Restart()
    {
        LoadData();
        StartStage();
    }

    public void AddPoint(int point)
    {
        curPoint += point;
        Debug.Log($"현재 포인트는 : {curPoint} 입니다.");
    }
}
