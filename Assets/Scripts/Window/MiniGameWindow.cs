using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MiniGameWindow : MonoBehaviour
{
    private GameConfig.MiniGamePackageData _miniGamePackageData;
    public int _arrowSpawnCount;
    public float _arrowSpawnTime;
    public float _arrowSpeed;

    public NoteController _theNoteController;
    
    public void SetData()
    {
        _arrowSpawnCount = _miniGamePackageData.ArrowSpawnCount;
        _arrowSpawnTime = _miniGamePackageData.ArrowSpawnTime;
        _arrowSpeed = _miniGamePackageData.ArrowSpeed;
    }

    public void Open(GameConfig.MiniGamePackageData miniGamePackageData)
    {
        Debug.Log("MiniGameWindow Open");
        _miniGamePackageData = miniGamePackageData;
        
        SetData();
        
        gameObject.SetActive(true);
        
        _theNoteController.SetData(_miniGamePackageData);
    }
}
