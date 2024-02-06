using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Encounter : Encounter
{
    public Battle_Encounter(string name, bool precondition, string beforeContext, object reward) : base(name, precondition, beforeContext)
    {
        base.reward = reward;
    }

    public override void Encount()
    {
        BattleManager.Instance.StartBattle(0);
        base.Encount();
    }

    public override void Complete()
    {
        base.Complete();
    }
}
