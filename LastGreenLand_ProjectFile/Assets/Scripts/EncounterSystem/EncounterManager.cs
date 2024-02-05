using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;


//EncounterSystem.cs���� �а� �� ��
public class EncounterManager : MonoBehaviour
{
    #region Treasure_Encounter�� ���� ������
    public GameObject treasureLightPrefab;
    public GameObject Background;
    #endregion

    #region Selection_Encounter�� ���� ������
    public GameObject[] panelObjs;  //���� ����Ƽscene�� 5�� ����
    [HideInInspector] public TMP_Text[] panelTexts;
    #endregion

    public Encounter ongoingEncounter;

    //�̱��� ����
    public static EncounterManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;    //�̱��� ����

        //panelObject�� �����ϴ� TMP_Text �Ҵ�
        panelTexts = new TMP_Text[panelObjs.Length];
        for (int i = 0; i < panelObjs.Length; i++)
            panelTexts[i] = panelObjs[i].transform.Find("Text").GetComponent<TMP_Text>(); //�ڽĿ�����Ʈ �߿��� �̸����� �˻��ؼ� �Ҵ�
    }

    public void SelectOption(int optionIndex)
    {
        Selection_Encounter ongoingEncounter = this.ongoingEncounter as Selection_Encounter;
        if (ongoingEncounter == null) Debug.Log("[����] EncounterManager�� Select()���� ongoingEnounter�� null");
        ongoingEncounter?.Select(optionIndex);
    }
}
