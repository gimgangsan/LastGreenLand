using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_Encounter : Encounter
{
    public Treasure_Encounter()
    {
        beforeContext = "��ó�� ������ ������ ���Դϴ�.";
    }

    public override void Encount()
    {
        base.Encount();
        TreasureManager.Instance.ongoingEncounter = this;

        //������ ����
        GameObject light = GameObject.Instantiate(TreasureManager.Instance.treasureLightPrefab);

        //������ ��ġ ����
        light.transform.SetParent(TreasureManager.Instance.Background.transform);
        light.transform.localPosition = new Vector3(Random.Range(-0.8f, 0.8f),
                                                    Random.Range(-0.8f, 0.8f),
                                                    0);

        light.GetComponent<TreasureLight>().CompleteEncounter = new System.Action(Complete);
    }

    public override void Complete()
    {
        base.Complete();
        TreasureManager.Instance.ongoingEncounter = null;
    }
}
