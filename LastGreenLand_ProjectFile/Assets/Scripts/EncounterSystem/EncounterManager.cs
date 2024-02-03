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

    #region Treasure_Encounter�� ���� ������
    public GameObject treasureLightPrefab;
    public GameObject Background;
    #endregion

    #region Selection_Encounter�� ���� ������
    public GameObject[] panelObjs;  //���� ����Ƽscene�� 5�� ����
    [HideInInspector] public TMP_Text[] panelTexts;
    #endregion

    //�̱��� ����
    public static EncounterManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;    //�̱��� ����

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
}
