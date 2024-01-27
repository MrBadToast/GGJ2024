using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public int bpm = 0;
    private double currentTime = 0d;
    [SerializeField] private Transform tfNoteAppear;
    [SerializeField] private GameObject goNote;

    public TimingManager timingManager;
    public float waitToCreate;
    
    private GameConfig.MiniGamePackageData _miniGamePackageData;
    public void SetData(GameConfig.MiniGamePackageData miniGamePackageData)
    {
        _miniGamePackageData = miniGamePackageData;
    }

    public void CreateArrowNote()
    {
        if (currentTime >= 60d / bpm)
        {
            for (int i = 0; i < _miniGamePackageData.ArrowSpawnCount; i++)
            {
                GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
                t_note.transform.SetParent(transform);
                TimingManager.instance.isEnter = false;
            }
            currentTime -= 60d / bpm;
        }
    }

    // Update is called once per frame
    void Update()
    {
        waitToCreate -= Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(transform);
            currentTime -= 60d / bpm;
            TimingManager.instance.isEnter = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            Destroy(other.gameObject);
        }
    }
}
