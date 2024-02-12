using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Encounter : Encounter
{
    protected string beforeContext;      // 인카운터에 대한 상황 설명, 또는 인카운터가 발생한 맥락

    public override void Encount()
    {
        base.Encount();

        // beforeContext에 대한 로그 출력
        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);

        // 전투 시작
        BattleManager.Instance.ongoingEncounter = this; // 진행 중인 인카운터가 있음을 알리기 위해
        BattleManager.Instance.StartBattle(0);          // 매개변수는 임의로 채워넣음 (나중에 적이 늘어나면 바꿔야 함)
    }

    public override void Complete()
    {
        base.Complete();
        BattleManager.Instance.ongoingEncounter = null; // 진행 중인 인카운터가 없음을 알리기 위해
    }
}