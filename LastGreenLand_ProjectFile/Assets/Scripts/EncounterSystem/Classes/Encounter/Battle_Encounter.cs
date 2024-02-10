using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Encounter : Encounter
{
    protected string beforeContext;      //인카운터에 대한 상황 설명, 또는 인카운터가 발생한 맥락

    public override void Encount()
    {
        base.Encount();

        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);

        BattleManager.Instance.ongoingEncounter = this;
        BattleManager.Instance.StartBattle(0);
    }

    public override void Complete()
    {
        base.Complete();
        BattleManager.Instance.ongoingEncounter = null;
    }
}