using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 살인마와의_싸움 : Battle_Encounter
{
    public 살인마와의_싸움()
    {
        precondition = true;
        beforeContext = "살인마와의 싸움이 시작됩니다.";
    }

    public override void Complete()
    {
        base.Complete();
        new RewardItem("피묻은 칼").GetReward();
    }
}

