using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public GameObject[] panelObjs;                  // �г�UI, ���� ����Ƽscene�� 5�� ����
    [HideInInspector] public TMP_Text[] panelTexts; // �г�UI�� �ڽ� ������Ʈ

    public Scenario �׽�Ʈ�ó����� = new Scenario(
        new �ָ���_�����_�׸��ڸ�_�߰�()
    );

    /// <summary>
    /// ���� ���� ��ī����
    /// </summary>
    public Selection_Encounter ongoingEncounter;

    public static SelectionManager Instance { get; private set; }   // �̱��� ����

    void Awake()
    {
        Instance = this;    //�̱��� ����

        //panelObject�� �����ϴ� TMP_Text �Ҵ�
        panelTexts = new TMP_Text[panelObjs.Length];
        for (int i = 0; i < panelObjs.Length; i++)
            panelTexts[i] = panelObjs[i].transform.Find("Text").GetComponent<TMP_Text>(); //�ڽĿ�����Ʈ �߿��� �̸����� �˻��ؼ� �Ҵ�
    }

    /// <summary>
    /// ongoingEncounter�� Select�޼ҵ� ȣ��
    /// </summary>
    /// <param name="optionIndex">������ �迭�� �ε���</param>
    public void SelectOption(int optionIndex)
    {
        ongoingEncounter.Select(optionIndex);
    }

    /// <summary>
    /// ������ Selection Encounter ����
    /// </summary>
    public void Encount()
    {
        �׽�Ʈ�ó�����.GetRandomEncounter.Encount();
    }
}
