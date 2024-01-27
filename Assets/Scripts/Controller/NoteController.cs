using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private double currentTime = 0d;
    [SerializeField] private Transform tfNoteAppear;
    [SerializeField] private GameObject goNote;

    public TimingManager timingManager;
    public float waitToSpawnTime;
    public int spawnCount;
    
    private GameConfig.MiniGamePackageData _miniGamePackageData;

    public bool isStart;

    public List<GameObject> noteList = new();
    public void SetData(GameConfig.MiniGamePackageData miniGamePackageData)
    {
        _miniGamePackageData = miniGamePackageData;
        spawnCount = miniGamePackageData.ArrowSpawnCount;
        waitToSpawnTime = miniGamePackageData.ArrowSpawnTime;

        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("ONE");
        
        yield return new WaitForSeconds(1f);
        Debug.Log("TWO");
        
        yield return new WaitForSeconds(.5f);
        Debug.Log("THREE");
        
        isStart = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (isStart == false) 
            return;
        
        if (spawnCount > 0)
        {
            waitToSpawnTime -= Time.deltaTime;
            //Debug.Log($"waitToSpawnTime :: {waitToSpawnTime}");

            if (waitToSpawnTime <= 0)
            {
                Debug.Log(spawnCount);

                GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
                t_note.transform.SetParent(transform);
                noteList.Add(t_note);
                TimingManager.instance.isEnter = false;
                spawnCount--;
                waitToSpawnTime = _miniGamePackageData.ArrowSpawnTime;
            }
        }

        if (spawnCount <= 0 && noteList.Count <= 0)
        {
            GuestController.instance.AudienceReaction(TimingManager.instance.score,
                _miniGamePackageData.ArrowSpawnCount);
            UIManager.instance.miniGameWindow.gameObject.SetActive(false);
            isStart = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            Destroy(other.gameObject);
            noteList.Remove(other.gameObject);
        }
    }
}
