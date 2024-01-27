using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = System.Random;

public class ComedySelectWindow : MonoBehaviour
{
    private GameConfig.StageLevelData _levelData;

    public Button[] buttons;
    
    public TMP_Text txtOptionHint;
    public TMP_Text txtOptionAnswer;
    public TMP_Text txtOptionWrongAnswer_1;
    public TMP_Text txtOptionWrongAnswer_2;
    
    public List<string> answerList = new();
    private Random rng = new();

    JokeOptions currentJokeOption;

    public void SetData()
    {
        currentJokeOption = GameManager.instance.gameConfig.PickRandomJokeOption();
        txtOptionHint.text = currentJokeOption.hint;
        
        if(answerList.Count > 1)
            answerList.Clear();
        
        answerList.Add(currentJokeOption.proper);
        answerList.Add(currentJokeOption.wrong1);
        answerList.Add(currentJokeOption.wrong2);

        Shuffle(answerList);

        txtOptionAnswer.text = answerList[0];
        txtOptionWrongAnswer_1.text = answerList[1];
        txtOptionWrongAnswer_2.text = answerList[2];
    }
    
    public void Shuffle(List<string> list)  
    {
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            (list[k], list[n]) = (list[n], list[k]);
        }  
    }
    public void Open(GameConfig.StageLevelData levelData)
    {
        _levelData = levelData;
        SetData();
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < buttons.Length; i++)
        {
            var capturedIndex = i;
            buttons[capturedIndex].onClick.AddListener(() =>
            {
                if (answerList[capturedIndex].Equals(currentJokeOption.proper))
                {
                    Debug.Log("정답입니다.");
                    StageController.instance.AddPoint(_levelData.DefaultPoint * _levelData.AnswerBonusTimes);
                    gameObject.SetActive(false);
                    UIManager.instance.miniGameWindow.Open(_levelData.MiniGamePackage);
                }
                else
                {
                    Debug.Log("틀렸습니다.");
                    StageController.instance.AddPoint(_levelData.DefaultPoint * _levelData.WrongAnswerTimes);
                    gameObject.SetActive(false);
                    UIManager.instance.miniGameWindow.Open(_levelData.MiniGamePackage);
                }
              
            });
        }
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
