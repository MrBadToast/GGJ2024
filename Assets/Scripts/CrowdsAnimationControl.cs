using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdsAnimationControl : MonoBehaviour
{
    public DOTweenAnimation[] crowdList;

    public void PauseAll()
    {
        foreach (var c in crowdList)
        {
            c.DOPause();
        }
    }

    public void PlayAll()
    {
        foreach (var c in crowdList)
        {
            c.DOPlay();
        }
    }

}
