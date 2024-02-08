using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;


public class SelectionManager : MonoBehaviour
{
    public GameObject[] panelObjs;  //현재 유니티scene에 5개 존재
    [HideInInspector] public TMP_Text[] panelTexts;

    public Scenario 테스트시나리오 = new Scenario(
        new 멀리서_사람의_그림자를_발견()
    );

    public Selection_Encounter ongoingEncounter;
    //싱글턴 패턴
    public static SelectionManager Instance { get; private set; }

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
        ongoingEncounter.Select(optionIndex);
    }
}
