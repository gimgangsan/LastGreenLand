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
    public (StatusPage.ContentsIndex index, int amount)[] increments;
    public RewardStat(params (StatusPage.ContentsIndex index, int amount)[] increments)
    {
        this.increments = increments;
    }

    public void GetReward()
    {
        foreach (var increment in increments) { 
            switch(increment.index)
            {
                case StatusPage.ContentsIndex.hp:
                    GameManager.Instance.currentHealth += increment.amount;
                    Debug.Log($"현재 체력이 {increment.amount}만큼 회복됩니다.");
                    LogManager.Instance.AddLog($"현재 체력이 {increment.amount}만큼 회복됩니다.");
                    break;
                case StatusPage.ContentsIndex.maxhp:
                    GameManager.Instance.maxHealth += increment.amount;
                    Debug.Log($"최대 체력이 {increment.amount}만큼 증가합니다.");
                    LogManager.Instance.AddLog($"최대 체력이 {increment.amount}만큼 증가합니다.");
                    break;
                case StatusPage.ContentsIndex.strength:
                    GameManager.Instance.strength += increment.amount;
                    Debug.Log($"힘이 {increment.amount}만큼 치솟습니다.");
                    LogManager.Instance.AddLog($"힘이 {increment.amount}만큼 치솟습니다.");
                    break;
            }
        }
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
