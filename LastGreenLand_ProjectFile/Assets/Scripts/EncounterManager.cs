using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


//EncounterSystem.cs���� �а� �� ��
public class EncounterManager : MonoBehaviour
{
    public Episode testEpisode = new Episode(); //�׽�Ʈ�� ���Ǽҵ�
    public Encounter goingEncounter;    //���� ���� ���� ��ī����

    public GameObject[] panelObjs;  //���� ����Ƽscene�� 5�� ����
    TMP_Text[] panelTexts;

    void Awake()
    {
        //panelObject�� �����ϴ� TMP_Text �Ҵ�
        panelTexts = new TMP_Text[panelObjs.Length];
        for (int i = 0; i < panelObjs.Length; i++)
            panelTexts[i] = panelObjs[i].transform.Find("Text").GetComponent<TMP_Text>(); //�ڽĿ�����Ʈ �߿��� �̸����� �˻��ؼ� �Ҵ�

        //���Ǽҵ� �ȿ� ��ī���� ����
        testEpisode.CreateEncounter("����(1)",                  //�̸�
                                    true,                       //��������
                                    "���� ���� �߰��ߴ�!",      //��Ȳ����
                                    new Encounter.Option[] {    //������
                                        new("���� ����", "�ؾ��� �賶"),
                                        new("�����Ѵ�", -10),
                                        new("���� ������", 1) }
                                    );
    }

    public void Encount(Episode episode)    //��ī���� ����, Explore.cs���� ȣ��
    {
        goingEncounter = episode.GetRandomEncounter;      //�����ϰ� �ϳ� �̱�

        Debug.Log(goingEncounter.context);     //context�� å�� ���̵��� ���� �ʿ�

        for (int i = 0; i < panelTexts.Length; i++)
        {
            if (i < goingEncounter.options.Length) //������ ������ŭ
            {
                panelObjs[i].SetActive(true);                           //������ Ȱ��ȭ
                panelTexts[i].text = goingEncounter.options[i].script;  //�ؽ�Ʈ ����
            }
            else
            {
                panelObjs[i].SetActive(false);  //������ �������� ���� �� ��Ȱ��ȭ
            }
        }
    }

    //panelObjs�� ��ư������Ʈ�� ���� ȣ��
    public void Complete(int optionIndex)
    {
        foreach(GameObject panel in panelObjs)
            panel.SetActive(false);

        goingEncounter.GetReward(optionIndex);
        goingEncounter = null;
    }
}
