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
    public TMP_Text txtOptionResult;
    
    public List<string> answerList = new();
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    private Random rng = new();

    JokeOptions currentJokeOption;

    public void SetData()
    {
        txtOptionResult.text = string.Empty;
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
    void OnEnable()
    {
        for (var i = 0; i < buttons.Length; i++)
        {
            var capturedIndex = i;
            buttons[capturedIndex].onClick.AddListener(() =>
            {
                if (answerList[capturedIndex].Equals(currentJokeOption.proper))
                {
                    Debug.Log("정답입니다.");
                    txtOptionResult.color = new Color(0.455f, 0.718f, 0.18f);
                    txtOptionResult.text = "청중 공략 성공! 보너스 점수 적용";
                    audioSource.PlayOneShot(correctSound);
                    StageController.instance.AddPoint(_levelData.DefaultPoint * _levelData.AnswerBonusTimes);
                    foreach(var b in buttons)
                    {
                        b.onClick.RemoveAllListeners();
                    }
                    Invoke("ProceedToMinigame",3.0f);

                }
                else
                {
                    Debug.Log("틀렸습니다.");
                    txtOptionResult.color = new Color(1.0f, 0.49f, 0.31f);
                    txtOptionResult.text = "청중 공략 실패...";
                    audioSource.PlayOneShot(wrongSound);
                    StageController.instance.AddPoint(_levelData.DefaultPoint * _levelData.WrongAnswerTimes);
                    foreach (var b in buttons)
                    {
                        b.onClick.RemoveAllListeners();
                    }
                    Invoke("ProceedToMinigame", 3.0f);
                }
              
            });
        }
   
    }

    public void ProceedToMinigame()
    {
        gameObject.SetActive(false);
        UIManager.instance.miniGameWindow.Open(_levelData.MiniGamePackage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
