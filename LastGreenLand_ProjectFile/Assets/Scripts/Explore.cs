using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


//EncounterSystem.cs�� ���� ���� EncounterManager.cs�� �а� ���� ���� ��
public class Explore : MonoBehaviour
{
    public Animator EffectAnimator;

    void Update()
    {
        if (EncounterManager.Instance.ongoingEncounter == null && Input.GetKeyUp(KeyCode.Space))    //encounter ���� �߿��� Ž�� �Ұ�
        {
            EffectAnimator.SetTrigger("Walk");
            EncounterDB.�׽�Ʈ�ó�����.GetRandomEncounter.Encount();
        }
    }

}
