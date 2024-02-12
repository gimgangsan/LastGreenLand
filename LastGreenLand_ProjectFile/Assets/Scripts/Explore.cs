using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Explore : MonoBehaviour
{
    public Animator EffectAnimator;

    bool isEncounterGoing { // ���� ���� ��ī���Ͱ� �ִ°�
        get {
            return
                SelectionManager.Instance.ongoingEncounter != null ||
                BattleManager.Instance.ongoingEncounter != null;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !isEncounterGoing) // ��ī���� ���� �߿��� Ž�� �Ұ�
        {
            EffectAnimator.SetTrigger("Walk");
            Encount();
        }
    }

    void Encount()  // �����ϰ� ��ī���� �߻�
    {
        switch (Random.Range(0, 2))
        {
            case 0: TreasureManager.Instance.Encount();     break;
            case 1: SelectionManager.Instance.Encount();    break;
        }
    }
}
