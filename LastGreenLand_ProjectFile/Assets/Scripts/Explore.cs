using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


//EncounterSystem.cs를 읽은 다음 EncounterManager.cs를 읽고 나서 읽을 것
public class Explore : MonoBehaviour
{
    public Animator EffectAnimator;
    public EncounterManager encounterManager;

    void Update()
    {
        if (encounterManager.goingEncounter == null&& Input.GetKeyUp(KeyCode.Space))    //encounter 진행 중에는 탐색 불가
        {
            EffectAnimator.SetTrigger("Walk");
            encounterManager.Encount(encounterManager.testEpisode);
        }
    }

}
