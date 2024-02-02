using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//��ī���� �ý����� �����ϱ� ���� �ڷ������� ��Ƴ���
public class Encounter
{
    public string name;         //������ ��ī���ʹ� List<Encounter>�� ���� �����Ǵµ�, �ε��������δ� ��ī���Ͱ� ���� �������� ����ϱ� �����Ƿ�
    public bool precondition;   //���� ����, �ش� ��ī���͸� ������ �ڰ��� �ִ°�?
    public int completeCount;   //�ش� ��ī���͸� �� �� �����ߴ°�? �� �� ���� �����ؾ� �ϰų�, ������ �����ؾ� ���� ��ī���Ͱ� �رݵǴ� �ý��ۿ� ����� ����
    public string context;      //��ī���Ϳ� ���� ��Ȳ ����, �Ǵ� ��ī���Ͱ� �߻��� �ƶ�

    public struct Option {  //������ ����ü
        public string script;   //�������� �� ���
        public object reward;   //���� �ڷ����� ���� ��, is �����ڷ� ó���� ����, ���� �� �������� ���� �ڷ����� �ʿ�

        public Option(string script, object reward) {
            this.script = script;
            this.reward = reward;
        }
    }
    public Option[] options;    //������

    public void GetReward(int optionIndex)   //�������� ���� reward ó��
    {
        completeCount++;    //�ش� ��ī���͸� �� �� �����ߴ°�?
        object reward = options[optionIndex].reward;

        if (reward is int) {         //�ڷ����� int��� (������ ���� �ڷ����� �ʿ�)
            Debug.Log($"������ {reward}��ŭ �ö����ϴ�. \n({completeCount}�� ����)");
        }
        else if(reward is string) { //�ڷ����� string�̶�� (�������� ���� �ڷ����� �ʿ�)
            Debug.Log($"������ \"{reward}\"��(��) ������ϴ�. \n({completeCount}�� ����)");
        }
    }
}

public class Episode   //��ī���Ͱ� �� ���Ǽҵ带 �̷��, ���Ǽҵ尡 �� ���ӽ��丮�� �̷�� ������ ��ȹ ��
{
    public List<Encounter> episode = new List<Encounter>();

    public List<Encounter> PossibleEpisode  //���������� ������ ��ī���͸� ����
    {
        get { return episode.Where(ep => ep.precondition).ToList(); }
    }

    public Encounter GetRandomEncounter     //���������� ������ ��ī���� �� �������� �ϳ� �̱�
    {
        get { return PossibleEpisode[Random.Range(0, PossibleEpisode.Count)]; }
    }

    public void CreateEncounter(string name, bool precondition, string context, Encounter.Option[] options)
    {
        Encounter newEncounter = new Encounter();
        newEncounter.name           = name;
        newEncounter.precondition   = precondition;
        newEncounter.context        = context;
        newEncounter.options        = options;

        episode.Add(newEncounter);  //���Ǽҵ忡 ��ī���� �߰�
    }
}
