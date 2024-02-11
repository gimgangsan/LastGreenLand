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
        if (Input.GetKeyUp(KeyCode.Space) &&    //encounter ���� �߿��� Ž�� �Ұ�
            TreasureManager.Instance.ongoingEncounters.Count == 0 &&
            SelectionManager.Instance.ongoingEncounter == null &&
            BattleManager.Instance.ongoingEncounter == null)
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
                TreasureManager.Instance.Encount(); break;
            case 1:
                SelectionManager.Instance.Encount(); break;
        }
    }
}
