using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TimingManager : MonoBehaviour
{
    public static TimingManager instance;
    private void Awake() => instance = this;

    public bool isEnter = false;
    public Note curNote;
    
    // Update is called once per frame
    void Update()
    {
        var keyCode = Event.current.keyCode;
        if (isEnter == true)
        {
            if (keyCode == curNote.key)
            {
                Debug.Log("Hit");
                Destroy(curNote.gameObject);
            }
        }
        else
        {
            Debug.Log("Miss");
        }
    }
}
