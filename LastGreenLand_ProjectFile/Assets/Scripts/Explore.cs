using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Explore : MonoBehaviour
{
    public Animator EffectAnimator;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            EffectAnimator.SetTrigger("Walk");
    }
}
