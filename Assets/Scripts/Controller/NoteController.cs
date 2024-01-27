using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NoteController : MonoBehaviour
{
    private double currentTime = 0d;
    [SerializeField] private Transform tfNoteAppear;
    [SerializeField] private GameObject goNote;

    public TimingManager timingManager;
    public float waitToSpawnTime;
    public int spawnCount;
    
    private GameConfig.MiniGamePackageData _miniGamePackageData;
    public void SetData(GameConfig.MiniGamePackageData miniGamePackageData)
    {
        _miniGamePackageData = miniGamePackageData;
        spawnCount = miniGamePackageData.ArrowSpawnCount - 1;
        waitToSpawnTime = miniGamePackageData.ArrowSpawnTime;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (spawnCount > 0)
        {
            waitToSpawnTime -= Time.deltaTime;
            Debug.Log($"waitToSpawnTime :: {waitToSpawnTime}");
            
            if (waitToSpawnTime <= 0)
            {
                Debug.Log(spawnCount);
                
                GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
                t_note.transform.SetParent(transform);
                TimingManager.instance.isEnter = false;
                spawnCount--;
                waitToSpawnTime = _miniGamePackageData.ArrowSpawnTime;
            }
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
