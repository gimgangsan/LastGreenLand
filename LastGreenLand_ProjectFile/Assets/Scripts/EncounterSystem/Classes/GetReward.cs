using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using static StatusPage;

public interface IGetReward
{
    public void GetReward();
}

/// <summary>
/// 아이템 획득을 처리하는 클래스
/// </summary>
public class RewardItem : IGetReward
{
    public string item; // 보상으로 얻을 아이템

    /// <summary>
    /// 얻을 아이템을 입력
    /// </summary>
    /// <param name="item">얻을 아이템</param>
    public RewardItem(string item)
    {
        this.item = item;
    }

    /// <summary>
    /// 현재로서는 로그만 출력
    /// </summary>
    public void GetReward()
    {
        Debug.Log($"아이템 {item}을(를) 얻었습니다.");
    }
}

/// <summary>
/// 스탯 획득을 처리하는 클래스
/// </summary>
public class RewardStat : IGetReward
{
    ContentsIndex index;    // 변화시킬 스탯
    int amount;             // 변화량

    /// <summary>
    /// 얻을 스탯의 정보를 입력
    /// </summary>
    /// <param name="index">변화시킬 스탯</param>
    /// <param name="amount">변화량</param>
    public RewardStat(ContentsIndex index, int amount)
    {
        this.index = index;
        this.amount = amount;
    }

    /// <summary>
    /// StatusPage에 접근해서 스탯 변경, 로그 출력
    /// </summary>
    public void GetReward()
    {
        // 스탯 상승
        StatusPage.Instance.GetContent(index).Info += amount;

        // 로그 출력
        Debug.Log($"{index} {amount:+#;-#;0}");     // (+#;-#;0 : 부호를 표시하겠다)
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
