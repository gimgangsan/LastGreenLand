using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    object a = 1;
    void Start()
    {
        var b = a;
        Debug.Log(a.GetType());
    }
}
