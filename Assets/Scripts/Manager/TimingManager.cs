using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public static TimingManager instance;
    private void Awake() => instance = this;

    public bool isEnter = false;
    public GameObject curObj;
    
    // Update is called once per frame
    void Update()
    {
        if (isEnter == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Hit");
                Destroy(curObj);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
                Debug.Log("Miss");
        }
    }
}
