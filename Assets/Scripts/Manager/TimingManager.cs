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
    public int score;

    public NoteController theNoteController;
    
    // Update is called once per frame
    void Update()
    {
        if (isEnter == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && curNote.key == KeyCode.RightArrow)
            {
                if (curNote != null)
                {
                    Debug.Log("Hit");
                    StageController.instance.AddPoint(10);
                    score++;
                    theNoteController.noteList.Remove(curNote.gameObject);
                    
                    if(AudioManager.instance != null)
                        AudioManager.instance.PlayRandomMiniGameMusic();
                    
                    Destroy(curNote.gameObject);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.LeftArrow) && curNote.key == KeyCode.LeftArrow)
            {
                if (curNote != null)
                {
                    Debug.Log("Hit");
                    StageController.instance.AddPoint(10);
                    score++;
                    theNoteController.noteList.Remove(curNote.gameObject);
                    
                    if(AudioManager.instance != null)
                        AudioManager.instance.PlayRandomMiniGameMusic();
                    
                    Destroy(curNote.gameObject);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow) && curNote.key == KeyCode.UpArrow)
            {
                if (curNote != null)
                {
                    Debug.Log("Hit");
                    StageController.instance.AddPoint(10);
                    score++;
                    theNoteController.noteList.Remove(curNote.gameObject);
                    
                    if(AudioManager.instance != null)
                        AudioManager.instance.PlayRandomMiniGameMusic();
                    
                    Destroy(curNote.gameObject);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow) && curNote.key == KeyCode.DownArrow)
            {
                if (curNote != null)
                {
                    Debug.Log("Hit");
                    StageController.instance.AddPoint(10);
                    score++;
                    theNoteController.noteList.Remove(curNote.gameObject);
                    
                    if(AudioManager.instance != null)
                        AudioManager.instance.PlayRandomMiniGameMusic();
                    
                    Destroy(curNote.gameObject);
                }
            }
        }
        else
        {
            if(Input.anyKey)
                Debug.Log("Miss");
        }
    }
}
