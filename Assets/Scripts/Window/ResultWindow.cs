using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ResultWindow : MonoBehaviour
{
    public int completePoint;

    public GameObject CurrentScoreText;
    public GameObject TotalScoreText;
    public GameObject NextScoreText;

    public void SetData()
    {
        completePoint = StageController.instance.CurStageLevelData.CompletePoint;
    }

    public void Open()
    {
        SetData();
        gameObject.SetActive(true);

        Debug.Log("점수를 계산합니다.");

        StartCoroutine(CalculateProgress());
    }

    IEnumerator CalculateProgress()
    {
        CurrentScoreText.SetActive(true);
        CurrentScoreText.GetComponent<TextMeshProUGUI>().text = "현재 점수 " + StageController.instance.curPoint.ToString();
        // 애니메이션 - 이번 점수 내려가는 애니메이션
        yield return new WaitForSeconds(0.5f);

        TotalScoreText.SetActive(true);
        TotalScoreText.GetComponent<TextMeshProUGUI>().text = "누적 점수 " + GameManager.instance.totalScore.ToString();
        // 애니메이션 - 누적 점수 올라가는 애니메이션
        yield return new WaitForSeconds(2f);

        for(int i = 0; i < StageController.instance.curPoint; i+=1)
        {
            CurrentScoreText.GetComponent<TextMeshProUGUI>().text = "현재 점수 " + (StageController.instance.curPoint - i).ToString();
            TotalScoreText.GetComponent<TextMeshProUGUI>().text = "누적 점수 " + (GameManager.instance.totalScore + i).ToString();
            yield return new WaitForFixedUpdate();
        }

        CurrentScoreText.GetComponent<TextMeshProUGUI>().text = "현재 점수 0";
        TotalScoreText.GetComponent<TextMeshProUGUI>().text = "누적 점수 " + (GameManager.instance.totalScore + StageController.instance.curPoint).ToString();


        GameManager.instance.totalScore += StageController.instance.curPoint;
        //여기서 Totalscore에 합산

        // 애니메이션 - 다음 스테이지 or 다음 스테이지 or 다시 도전
        yield return new WaitForSeconds(1f);

        int nextUntil = GameManager.instance.GetNextScore() - GameManager.instance.totalScore;

        NextScoreText.SetActive(true);
        if (StageController.instance.curLevel == Level.HARD)
        {
            if (nextUntil < 0) nextUntil = 0;
            NextScoreText.GetComponent<TextMeshProUGUI>().text = "엔딩까지 " + nextUntil;
        }
        else
        {
            if (nextUntil > 0)
                NextScoreText.GetComponent<TextMeshProUGUI>().text = "다음까지 " + nextUntil;
            else
                NextScoreText.GetComponent<TextMeshProUGUI>().text = "난이도 상승";
        }


        yield return new WaitForSeconds(2f);

        GetComponent<DOTweenAnimation>().DORestartAllById("FadeoutResult");
        Tween tween = GetComponent<DOTweenAnimation>().tween;

        yield return tween.WaitForCompletion();

        CurrentScoreText.SetActive(false);
        TotalScoreText.SetActive(false);
        NextScoreText.SetActive(false);

        GetComponent<CanvasGroup>().alpha = 1.0f;

        Result();
    }

    public void Result()
    {
        if (StageController.instance.curPoint < completePoint)
        {
            StageController.instance.Restart();
        }
        else if (StageController.instance.curPoint >= completePoint)
        {
            StageController.instance.NextLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StageController.instance.NextLevel();
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StageController.instance.Restart();
            gameObject.SetActive(false);
        }
    }
}
