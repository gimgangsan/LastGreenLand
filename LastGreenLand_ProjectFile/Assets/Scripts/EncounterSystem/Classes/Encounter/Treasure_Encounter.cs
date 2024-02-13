using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��¦���� ã�� ��ī����
/// </summary>
public class Treasure_Encounter : Encounter
{
    /// <summary>
    /// ��ī���� ���� // TreasureLight������ ����, ��������Ʈ �Ҵ�
    /// </summary>
    public override void Encount()
    {
        base.Encount();

        //������ ����
        GameObject light = GameObject.Instantiate(TreasureManager.Instance.treasureLightPrefab);

        // �������� Ŭ�� ���� �� ������ ��
        light.GetComponent<TreasureLight>().CompleteEncounter = new Action(Complete);
    }

    /// <summary>
    /// ��ī���Ͱ� ������ �� ȣ�� // �ƹ� ��� ����
    /// </summary>
    public override void Complete()
    {
        base.Complete();
    }
}
