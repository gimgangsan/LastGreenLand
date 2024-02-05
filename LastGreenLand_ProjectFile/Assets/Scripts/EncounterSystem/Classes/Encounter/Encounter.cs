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
    //��ó��
    public string name;         //������ ��ī���ʹ� List<Encounter>�� ���� �����Ǵµ�, �ε��������δ� ��ī���Ͱ� ���� �������� ����ϱ� �����Ƿ�
    public bool precondition;   //���� ����, �ش� ��ī���͸� ������ �ڰ��� �ִ°�?
    public int completeCount;   //��ī���͸� �Ϸ��� Ƚ��
    protected string beforeContext;      //��ī���Ϳ� ���� ��Ȳ ����, �Ǵ� ��ī���Ͱ� �߻��� �ƶ�

    //��ó��
    protected string afterContext;
    protected Encounter afterEncounter;
    protected object reward;

    protected Encounter(string name, bool precondition, string beforeContext)
    {
        this.name = name;
        this.precondition = precondition;
        this.beforeContext = beforeContext;
    }

    public virtual void Encount()
    {
        if (!precondition) return;
        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);
        EncounterManager.Instance.ongoingEncounter = this;
    }

    public virtual void Complete()
    {
        GetReward(reward);
        completeCount++;
        EncounterManager.Instance.ongoingEncounter = null;
        afterEncounter?.Encount();
    }

    void GetReward(object reward)   //reward ó��
    {
        if (reward is int) {         //�ڷ����� int��� (������ ���� �ڷ����� �ʿ�)
            Debug.Log($"������ {reward}��ŭ �ö����ϴ�.");
            LogManager.Instance.AddLog($"������ {reward}��ŭ �ö����ϴ�.");
        }
        else if(reward is string) { //�ڷ����� string�̶�� (�������� ���� �ڷ����� �ʿ�)
            Debug.Log($"������ \"{reward}\"��(��) ������ϴ�.");
            LogManager.Instance.AddLog($"������ \"{reward}\"��(��) ������ϴ�.");
        }
    }
}
