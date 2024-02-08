using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Encounter : Encounter
{
    public override void Encount()
    {
        base.Encount();
        BattleManager.Instance.ongoingEncounter = this;
        BattleManager.Instance.StartBattle(0);
    }

    public override void Complete()
    {
        base.Complete();
        BattleManager.Instance.ongoingEncounter = null;
    }
}