using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


//EncounterSystem.cs먼저 읽고 올 것
public class EncounterManager : MonoBehaviour
{
    public Episode testEpisode = new Episode(); //테스트용 에피소드
    public Encounter goingEncounter;    //현재 진행 중인 인카운터

    #region Treasure_Encounter를 위한 변수들
    public GameObject treasureLightPrefab;
    public GameObject Background;
    #endregion

    #region Selection_Encounter를 위한 변수들
    public GameObject[] panelObjs;  //현재 유니티scene에 5개 존재
    [HideInInspector] public TMP_Text[] panelTexts;
    #endregion

    //싱글턴 패턴
    public static EncounterManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;    //싱글턴 패턴

        //panelObject에 대응하는 TMP_Text 할당
        panelTexts = new TMP_Text[panelObjs.Length];
        for (int i = 0; i < panelObjs.Length; i++)
            panelTexts[i] = panelObjs[i].transform.Find("Text").GetComponent<TMP_Text>(); //자식오브젝트 중에서 이름으로 검색해서 할당

        //에피소드 안에 인카운터 생성
        testEpisode.CreateEncounter("지뢰(1)",                  //이름
                                    true,                       //선행조건
                                    "지뢰 밭을 발견했다!",      //상황설명
                                    new Encounter.Option[] {    //선택지
                                        new("피해 간다", "해어진 배낭"),
                                        new("돌파한다", -10),
                                        new("돌을 던진다", 1) }
                                    );
    }
}
