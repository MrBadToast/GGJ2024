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
        //Calculate();
    }

    public void Calculate()
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
