using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake() => instance = this;

    // 원하는 해상도 설정
    public int targetScreenWidth = 1920;
    public int targetScreenHeight = 1080;
    
    public ComedySelectWindow comedySelectWindow;
    public MiniGameWindow miniGameWindow;
    public ResultWindow resultWindow;
    
    void Start()
    {
        // 원하는 해상도로 설정
        SetResolution(targetScreenWidth, targetScreenHeight);
    }

    void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, true);
    }
}
