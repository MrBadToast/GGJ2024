using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBehaivor : MonoBehaviour
{
    [SerializeField] private string mainGameScene;

    void Start()
    {
        if(AudioManager.instance != null)
            AudioManager.instance.PlayMenuMusic();
    }

    public void LoadMainScene()
    {
        SceneLoader.Instance.LoadNewScene(mainGameScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
