using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;


//EncounterSystem.cs먼저 읽고 올 것
public class EncounterManager : MonoBehaviour
{
    #region Treasure_Encounter를 위한 변수들
    public GameObject treasureLightPrefab;
    public GameObject Background;
    #endregion

    #region Selection_Encounter를 위한 변수들
    public GameObject[] panelObjs;  //현재 유니티scene에 5개 존재
    [HideInInspector] public TMP_Text[] panelTexts;
    #endregion

    public Encounter ongoingEncounter;

    //싱글턴 패턴
    public static EncounterManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;    //싱글턴 패턴

        //panelObject에 대응하는 TMP_Text 할당
        panelTexts = new TMP_Text[panelObjs.Length];
        for (int i = 0; i < panelObjs.Length; i++)
            panelTexts[i] = panelObjs[i].transform.Find("Text").GetComponent<TMP_Text>(); //자식오브젝트 중에서 이름으로 검색해서 할당
    }

    public void SelectOption(int optionIndex)
    {
        Selection_Encounter ongoingEncounter = this.ongoingEncounter as Selection_Encounter;
        if (ongoingEncounter == null) Debug.Log("[오류] EncounterManager의 Select()에서 ongoingEnounter가 null");
        ongoingEncounter?.Select(optionIndex);
    }
}
