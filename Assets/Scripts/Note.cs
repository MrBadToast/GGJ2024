using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400f;

    private void Update()
    {
        transform.localPosition += Vector3.left * (Time.deltaTime * noteSpeed);
    }
}
