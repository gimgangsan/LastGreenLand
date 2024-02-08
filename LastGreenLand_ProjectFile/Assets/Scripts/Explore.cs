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
        if (TreasureManager.Instance.ongoingEncounter == null &&
            SelectionManager.Instance.ongoingEncounter == null &&
            BattleManager.Instance.ongoingEncounter == null &&
            Input.GetKeyUp(KeyCode.Space))    //encounter ���� �߿��� Ž�� �Ұ�
        {
            EffectAnimator.SetTrigger("Walk");
            Encount();
        }
    }

    void Encount()
    {
        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                TreasureManager.Instance.�׽�Ʈ�ó�����.GetRandomEncounter.Encount(); break;
            case 1:
                SelectionManager.Instance.�׽�Ʈ�ó�����.GetRandomEncounter.Encount(); break;
        }
    }
}
