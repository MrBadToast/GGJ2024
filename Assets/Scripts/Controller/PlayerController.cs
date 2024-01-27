using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake() => instance = this;

    public Animator anim;

    public void CorrectAnswer()
    {
        var rand = Random.Range(0,1);
        anim.SetTrigger(rand == 0 ? "Bored" : "SuperBored");
    }

    public void WrongAnswer()
    {
        var rand = Random.Range(0,1);
        anim.SetTrigger(rand == 0 ? "Angry" : "Sad");
    }
}
