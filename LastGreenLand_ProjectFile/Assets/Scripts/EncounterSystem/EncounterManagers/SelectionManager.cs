using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public GameObject[] panelObjs;                  // 패널UI, 현재 유니티scene에 5개 존재
    [HideInInspector] public TMP_Text[] panelTexts; // 패널UI의 자식 오브젝트

    public Scenario 테스트시나리오 = new Scenario(
        new 멀리서_사람의_그림자를_발견()
    );

    public Selection_Encounter ongoingEncounter;     // 진행 중인 인카운터가 있음을 알리기 위해

    public static SelectionManager Instance { get; private set; }   // 싱글톤 패턴

    void Awake()
    {
        Instance = this;    //싱글톤 패턴

        //panelObject에 대응하는 TMP_Text 할당
        panelTexts = new TMP_Text[panelObjs.Length];
        for (int i = 0; i < panelObjs.Length; i++)
            panelTexts[i] = panelObjs[i].transform.Find("Text").GetComponent<TMP_Text>(); //자식오브젝트 중에서 이름으로 검색해서 할당
    }

    public void SelectOption(int optionIndex)   // 선택함 (패널UI의 버튼 컴포넌트에서 호출)
    {
        ongoingEncounter.Select(optionIndex);
    }

    public void Encount()   // Explore에서 호출
    {
        테스트시나리오.GetRandomEncounter.Encount();
    }
}
