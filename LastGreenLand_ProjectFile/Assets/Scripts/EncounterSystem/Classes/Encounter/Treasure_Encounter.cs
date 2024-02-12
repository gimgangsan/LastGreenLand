using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_Encounter : Encounter
{
    public Treasure_Encounter() { }

    public override void Encount()
    {
        base.Encount();

        //������ ����
        GameObject light = GameObject.Instantiate(TreasureManager.Instance.treasureLightPrefab);

        //������ ��ġ ����
        light.transform.SetParent(TreasureManager.Instance.Background.transform);
        light.transform.localPosition = new Vector3(Random.Range(-0.8f, 0.8f),
                                                    Random.Range(-0.8f, 0.8f),
                                                    0);

        // �������� Ŭ�� ���� �� ������ ��
        light.GetComponent<TreasureLight>().CompleteEncounter = new System.Action(Complete);
    }

    public override void Complete()
    {
        base.Complete();
    }
}
