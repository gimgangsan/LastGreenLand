using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


//EncounterSystem.cs�� ���� ���� EncounterManager.cs�� �а� ���� ���� ��
public class Explore : MonoBehaviour
{
    public Animator EffectAnimator;
    public EncounterManager encounterManager;

    void Update()
    {
        if (encounterManager.goingEncounter == null&& Input.GetKeyUp(KeyCode.Space))    //encounter ���� �߿��� Ž�� �Ұ�
        {
            EffectAnimator.SetTrigger("Walk");
            encounterManager.Encount(encounterManager.testEpisode);
        }
    }

}
