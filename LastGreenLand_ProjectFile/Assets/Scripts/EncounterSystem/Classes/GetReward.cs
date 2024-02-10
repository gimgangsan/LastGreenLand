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
        Debug.Log($"������ {item}��(��) ������ϴ�.");
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
                    Debug.Log($"���� ü���� {increment.amount}��ŭ ȸ���˴ϴ�.");
                    LogManager.Instance.AddLog($"���� ü���� {increment.amount}��ŭ ȸ���˴ϴ�.");
                    break;
                case StatusPage.ContentsIndex.maxhp:
                    GameManager.Instance.maxHealth += increment.amount;
                    Debug.Log($"�ִ� ü���� {increment.amount}��ŭ �����մϴ�.");
                    LogManager.Instance.AddLog($"�ִ� ü���� {increment.amount}��ŭ �����մϴ�.");
                    break;
                case StatusPage.ContentsIndex.strength:
                    GameManager.Instance.strength += increment.amount;
                    Debug.Log($"���� {increment.amount}��ŭ ġ�ڽ��ϴ�.");
                    LogManager.Instance.AddLog($"���� {increment.amount}��ŭ ġ�ڽ��ϴ�.");
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
