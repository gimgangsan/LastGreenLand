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

    public GameObject[] panelObjs;  //현재 유니티scene에 5개 존재
    TMP_Text[] panelTexts;

    void Awake()
    {
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

    public void Encount(Episode episode)    //인카운터 시작, Explore.cs에서 호출
    {
        goingEncounter = episode.GetRandomEncounter;      //랜덤하게 하나 뽑기

        Debug.Log(goingEncounter.context);     //context가 책에 쓰이도록 구현 필요

        for (int i = 0; i < panelTexts.Length; i++)
        {
            if (i < goingEncounter.options.Length) //선택지 개수만큼
            {
                panelObjs[i].SetActive(true);                           //선택지 활성화
                panelTexts[i].text = goingEncounter.options[i].script;  //텍스트 갱신
            }
            else
            {
                panelObjs[i].SetActive(false);  //선택지 개수보다 많은 건 비활성화
            }
        }
    }

    //panelObjs의 버튼컴포넌트를 통해 호출
    public void Complete(int optionIndex)
    {
        foreach(GameObject panel in panelObjs)
            panel.SetActive(false);

        goingEncounter.GetReward(optionIndex);
        goingEncounter = null;
    }
}
