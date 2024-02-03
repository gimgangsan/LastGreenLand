using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//��ī���� �ý����� �����ϱ� ���� �ڷ������� ��Ƴ���
public class Encounter
{
    public string name;         //������ ��ī���ʹ� List<Encounter>�� ���� �����Ǵµ�, �ε��������δ� ��ī���Ͱ� ���� �������� ����ϱ� �����Ƿ�
    public bool precondition;   //���� ����, �ش� ��ī���͸� ������ �ڰ��� �ִ°�?
    protected string beforeContext;      //��ī���Ϳ� ���� ��Ȳ ����, �Ǵ� ��ī���Ͱ� �߻��� �ƶ�

    protected string succeeingContext;
    protected Encounter afterEncounter;
    protected object reward;

    public virtual void Encount()
    {
        if (precondition) return;
        LogManager.Instance.AddLog(beforeContext);
    }

    public virtual void Complete()
    {
        LogManager.Instance.AddLog(succeeingContext);
        GetReward(reward);
        afterEncounter?.Encount();
    }

    void GetReward(object reward)   //reward ó��
    {
        if (reward is int) {         //�ڷ����� int��� (������ ���� �ڷ����� �ʿ�)
            LogManager.Instance.AddLog($"������ {reward}��ŭ �ö����ϴ�.");
        }
        else if(reward is string) { //�ڷ����� string�̶�� (�������� ���� �ڷ����� �ʿ�)
            LogManager.Instance.AddLog($"������ \"{reward}\"��(��) ������ϴ�.");
        }
    }
}
