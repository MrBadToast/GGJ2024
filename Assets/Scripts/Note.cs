using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Note : MonoBehaviour
{
    public float noteSpeed = 0f;
    public KeyCode key;

    public Image img;
    public Sprite right, left, up, down;
    public string curArrowDirection;
    
    public void Start()
    {
        noteSpeed = StageController.instance.CurStageLevelData.MiniGamePackage.ArrowSpeed;

        //key = KeyCode.RightArrow;
        RandomArrow();
    }

    public void RandomArrow()
    {
        var rand = Random.Range(0, 3);

        switch (rand)
        {
            case 0:
                key = KeyCode.RightArrow;
                img.sprite = right;
                curArrowDirection = key.ToString();
                break;
            case 1:
                key = KeyCode.LeftArrow;
                img.sprite = left;
                curArrowDirection = key.ToString();
                break;
            case 2:
                key = KeyCode.UpArrow;
                img.sprite = up;
                curArrowDirection = key.ToString();
                break;
            case 3:
                key = KeyCode.DownArrow;
                img.sprite = down;
                curArrowDirection = key.ToString();
                break;
        }
    }

    private void Update()
    {
        transform.localPosition += Vector3.left * (Time.deltaTime * noteSpeed);
    }
}
