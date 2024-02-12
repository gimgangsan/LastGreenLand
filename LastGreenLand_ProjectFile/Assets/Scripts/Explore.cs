using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Explore : MonoBehaviour
{
    public Animator EffectAnimator;

    bool isEncounterGoing { // 진행 중인 인카운터가 있는가
        get {
            return
                SelectionManager.Instance.ongoingEncounter != null ||
                BattleManager.Instance.ongoingEncounter != null;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !isEncounterGoing) // 인카운터 진행 중에는 탐색 불가
        {
            EffectAnimator.SetTrigger("Walk");
            Encount();
        }
    }

    void Encount()  // 랜덤하게 인카운터 발생
    {
        switch (Random.Range(0, 2))
        {
            case 0: TreasureManager.Instance.Encount();     break;
            case 1: SelectionManager.Instance.Encount();    break;
        }
    }
}
