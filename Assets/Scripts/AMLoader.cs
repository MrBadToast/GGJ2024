using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMLoader : MonoBehaviour
{
    public AudioManager theAM;
    private void Awake()
    {
        if (AudioManager.instance == null)
            Instantiate(theAM);
    }
}
