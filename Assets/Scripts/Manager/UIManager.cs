using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake() => instance = this;

    public ComedySelectWindow comedySelectWindow;
    public MiniGameWindow miniGameWindow;
    public ResultWindow resultWindow;
    
}
