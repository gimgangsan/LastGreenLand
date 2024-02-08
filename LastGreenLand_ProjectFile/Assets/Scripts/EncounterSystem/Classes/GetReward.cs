using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public interface IGetReward
{
    public void GetReward();
}

public class RewardItem : IGetReward
{
    public string item;
    public RewardItem(string item)
    {
        this.item = item;
    }
    public void GetReward()
    {
        Debug.Log($"아이템 {item}을(를) 얻었습니다.");
    }
}

public class RewardStat : IGetReward
{
    public int stat;
    public RewardStat(int stat)
    {
        this.stat = stat;
    }

    public void GetReward()
    {
        Debug.Log($"스탯이 {stat}만큼 상승했습니다.");
    }
}


/*
public class RewardRandom
{
    public void GetReward()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            RewardItem reward = new();
            reward.GetReward();
            return;
        }
        else if (rand == 1)
        {
            RewardStat reward = new();
            reward.SetRandomReward();
            return;
        }
    }

    public void SetRandomReward() { }
}
*/
