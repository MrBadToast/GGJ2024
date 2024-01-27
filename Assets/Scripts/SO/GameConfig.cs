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

        public int DefaultPoint;
        public int WrongAnswerTimes;
        public int AnswerBonusTimes;
        
        public MiniGamePackageData MiniGamePackage;
    }

    public Level StartLevel;
    public StageLevelData[] StageLevelDatas;
    public JokeOptions[] jokeOptionsList;

    public JokeOptions PickRandomJokeOption()
    {
        return jokeOptionsList[Random.Range(0, jokeOptionsList.Length)];
    }
}
