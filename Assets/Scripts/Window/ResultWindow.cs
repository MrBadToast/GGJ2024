using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultWindow : MonoBehaviour
{
    public int completePoint;
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
        // 애니메이션 - 이번 점수 내려가는 애니메이션
        yield return new WaitForSeconds(0.5f);
        // 애니메이션 - 누적 점수 올라가는 애니메이션
        yield return new WaitForSeconds(0.5f);
        // 애니메이션 - 다음 스테이지 or 다음 스테이지 or 다시 도전
        yield return new WaitForSeconds(0.5f);

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
