using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Encounter : Encounter
{
    protected string beforeContext;      //��ī���Ϳ� ���� ��Ȳ ����, �Ǵ� ��ī���Ͱ� �߻��� �ƶ�

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