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
    public string item; // 보상으로 얻을 아이템

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
    StatusPage.ContentsIndex index; // 변화시킬 스탯
    int amount;                     // 변화량

    public RewardStat(StatusPage.ContentsIndex index, int amount)
    {
        this.index = index;
        this.amount = amount;
    }

    public void GetReward()
    {
        // 스탯 상승
        StatusPage.Instance.GetContent(index).Info += amount;
        StatusPage.Instance.GetContent(index).UpdateInfo(0);    // UpdateInfo에 왜 매개변수가 있는지 몰라서 아무거나 집어넣음

        // 로그 출력
        Debug.Log($"{index} {amount:+#;-#;0}");     // (+#;-#;0 : 부호 표시)
        LogManager.Instance.AddLog($"{index} {amount:+#;-#;0}");
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
