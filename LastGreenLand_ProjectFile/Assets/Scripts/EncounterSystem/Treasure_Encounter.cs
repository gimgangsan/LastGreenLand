using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_Encounter : Encounter
{
    public Treasure_Encounter(object reward)
    {
        base.reward = reward;
    }

    public Treasure_Encounter(Encounter afterEncounter)
    {
        base.afterEncounter = afterEncounter;
    }

    public Treasure_Encounter(object reward, Encounter afterEncounter)
    {
        base.reward = reward;
        base.afterEncounter = afterEncounter;
    }

    public override void Encount()
    {
        //프리팹 생성
        GameObject light = GameObject.Instantiate(EncounterManager.Instance.treasureLightPrefab);

        //프리팹 위치 변경
        light.transform.SetParent(EncounterManager.Instance.Background.transform);
        light.transform.localPosition = new Vector3(Random.Range(-0.8f, 0.8f),
                                                    Random.Range(-0.8f, 0.8f),
                                                    0);

        light.GetComponent<TreasureLight>().parentEncounter = this;
    }
}
