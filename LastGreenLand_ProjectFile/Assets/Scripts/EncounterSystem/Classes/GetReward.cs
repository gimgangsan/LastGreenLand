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
/// ������ ȹ���� ó���ϴ� Ŭ����
/// </summary>
public class RewardItem : IGetReward
{
    public string item; // �������� ���� ������

    /// <summary>
    /// ���� �������� �Է�
    /// </summary>
    /// <param name="item">���� ������</param>
    public RewardItem(string item)
    {
        this.item = item;
    }

    /// <summary>
    /// ����μ��� �α׸� ���
    /// </summary>
    public void GetReward()
    {
        Debug.Log($"������ {item}��(��) ������ϴ�.");
    }
}

/// <summary>
/// ���� ȹ���� ó���ϴ� Ŭ����
/// </summary>
public class RewardStat : IGetReward
{
    ContentsIndex index;    // ��ȭ��ų ����
    int amount;             // ��ȭ��

    /// <summary>
    /// ���� ������ ������ �Է�
    /// </summary>
    /// <param name="index">��ȭ��ų ����</param>
    /// <param name="amount">��ȭ��</param>
    public RewardStat(ContentsIndex index, int amount)
    {
        this.index = index;
        this.amount = amount;
    }

    /// <summary>
    /// StatusPage�� �����ؼ� ���� ����, �α� ���
    /// </summary>
    public void GetReward()
    {
        // ���� ���
        StatusPage.Instance.GetContent(index).Info += amount;

        // �α� ���
        Debug.Log($"{index} {amount:+#;-#;0}");     // (+#;-#;0 : ��ȣ�� ǥ���ϰڴ�)
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
