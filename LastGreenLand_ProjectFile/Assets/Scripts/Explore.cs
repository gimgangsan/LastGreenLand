using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


//EncounterSystem.cs를 읽은 다음 EncounterManager.cs를 읽고 나서 읽을 것
public class Explore : MonoBehaviour
{
    public Animator EffectAnimator;

    void Update()
    {
        if (EncounterManager.Instance.ongoingEncounter == null && Input.GetKeyUp(KeyCode.Space))    //encounter 진행 중에는 탐색 불가
        {
            EffectAnimator.SetTrigger("Walk");
            EncounterDB.테스트시나리오.GetRandomEncounter.Encount();
        }
    }

}
