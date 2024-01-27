using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            TimingManager.instance.isEnter = true;
            TimingManager.instance.curNote = other.GetComponent<Note>();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            TimingManager.instance.isEnter = false;
        }    
    }
}
