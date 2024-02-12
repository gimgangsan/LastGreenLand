using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ϴ� ��ī����
/// </summary>
public class Battle_Encounter : Encounter
{
    protected string beforeContext;      // ��ī���Ϳ� ���� ��Ȳ ����, �Ǵ� ��ī���Ͱ� �߻��� �ƶ�

    /// <summary>
    /// ��ī���� ���� // beforeContext ���, ongoingEncounter�� �ڽ��� ����, ���� ����
    /// </summary>
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

    /// <summary>
    /// ��ī���� ���� // ongoingEncounter�� null��
    /// </summary>
    public override void Complete()
    {
        base.Complete();
        BattleManager.Instance.ongoingEncounter = null; // ���� ���� ��ī���Ͱ� ������ �˸��� ����
    }
}