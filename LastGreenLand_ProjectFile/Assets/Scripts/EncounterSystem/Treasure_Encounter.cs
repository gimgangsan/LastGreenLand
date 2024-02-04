using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_Encounter : Encounter
{
    public Treasure_Encounter(string name, bool precondition, string beforeContext, object reward)
        : base(name, precondition, beforeContext)
    {
        base.reward = reward;
    }

    public Treasure_Encounter(string name, bool precondition, string beforeContext, Encounter afterEncounter)
        : base(name, precondition, beforeContext)
    {
        base.afterEncounter = afterEncounter;
    }

    public Treasure_Encounter(string name, bool precondition, string beforeContext, object reward, Encounter afterEncounter)
        : base(name, precondition, beforeContext)
    {
        base.reward = reward;
        base.afterEncounter = afterEncounter;
    }

    public override void Encount()
    {
        //������ ����
        GameObject light = GameObject.Instantiate(EncounterManager.Instance.treasureLightPrefab);

        //������ ��ġ ����
        light.transform.SetParent(EncounterManager.Instance.Background.transform);
        light.transform.localPosition = new Vector3(Random.Range(-0.8f, 0.8f),
                                                    Random.Range(-0.8f, 0.8f),
                                                    0);

        light.GetComponent<TreasureLight>().parentEncounter = this;
    }
}
