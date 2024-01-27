using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum Level
{
    EASY,
    NORMAL,
    HARD,
}

[CreateAssetMenu(fileName = "GameConfig", menuName = "Scriptable Object/GameConfig", order = int.MaxValue)]
public class GameConfig : ScriptableObject
{
    [System.Serializable]
    public struct MiniGamePackageData
    {
        public int ArrowSpawnCount;
        public float ArrowSpawnTime;
        public float ArrowSpeed;
    }
    
    [System.Serializable]
    public struct StageLevelData
    {
        public Level Name;
        public int CompletePoint;
        
        public string OptionHint;
        public string OptionAnswer;
        public string OptionWrongAnwser_1;
        public string OptionWrongAnwser_2;

        public int DefaultPoint;
        public int WrongAnswerTimes;
        public int AnswerBonusTimes;
        
        public MiniGamePackageData MiniGamePackage;
    }

    public Level StartLevel;
    public StageLevelData[] StageLevelDatas;
}
