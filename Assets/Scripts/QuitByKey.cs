using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitByKey : MonoBehaviour
{
    public KeyCode quitKey;

    private void Update()
    {
        if(Input.GetKeyDown(quitKey))
        {
            Application.Quit();
        }
    }

}
