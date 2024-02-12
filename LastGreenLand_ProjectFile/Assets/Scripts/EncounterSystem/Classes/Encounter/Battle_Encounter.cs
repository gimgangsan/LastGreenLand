using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Encounter : Encounter
{
    protected string beforeContext;      // ��ī���Ϳ� ���� ��Ȳ ����, �Ǵ� ��ī���Ͱ� �߻��� �ƶ�

    public override void Encount()
    {
        base.Encount();

        // beforeContext�� ���� �α� ���
        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);

        // ���� ����
        BattleManager.Instance.ongoingEncounter = this; // ���� ���� ��ī���Ͱ� ������ �˸��� ����
        BattleManager.Instance.StartBattle(0);          // �Ű������� ���Ƿ� ä������ (���߿� ���� �þ�� �ٲ�� ��)
    }

    public override void Complete()
    {
        base.Complete();
        BattleManager.Instance.ongoingEncounter = null; // ���� ���� ��ī���Ͱ� ������ �˸��� ����
    }
}