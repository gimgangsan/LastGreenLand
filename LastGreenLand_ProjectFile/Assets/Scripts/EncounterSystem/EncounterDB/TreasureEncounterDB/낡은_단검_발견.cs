using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 낡은_단검_발견 : Treasure_Encounter
{
    public 낡은_단검_발견()
    {
        precondition = true;
    }

    public override void Complete()
    {
        base.Complete();
        new RewardItem("낡은 단검").GetReward();
    }
}