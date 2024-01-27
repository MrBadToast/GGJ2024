using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            TimingManager.instance.isEnter = true;
            TimingManager.instance.curObj = other.gameObject;

        }
    }
}
