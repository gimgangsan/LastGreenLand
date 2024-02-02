using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//인카운터 시스템을 구현하기 위한 자료형들을 모아놓음
public class Encounter
{
    public string name;         //각각의 인카운터는 List<Encounter>를 통해 관리되는데, 인덱스만으로는 인카운터가 무슨 내용인지 기억하기 어려우므로
    public bool precondition;   //선행 조건, 해당 인카운터를 진행할 자격이 있는가?
    public int completeCount;   //해당 인카운터를 몇 번 진행했는가? 딱 한 번만 진행해야 하거나, 여러번 진행해야 다음 인카운터가 해금되는 시스템에 사용할 예정
    public string context;      //인카운터에 대한 상황 설명, 또는 인카운터가 발생한 맥락

    public struct Option {  //선택지 구조체
        public string script;   //선택지에 들어갈 대사
        public object reward;   //무슨 자료형이 들어갈지 모름, is 연산자로 처리할 예정, 스탯 및 아이템을 위한 자료형이 필요

        public Option(string script, object reward) {
            this.script = script;
            this.reward = reward;
        }
    }
    public Option[] options;    //선택지

    public void GetReward(int optionIndex)   //선택지에 대한 reward 처리
    {
        completeCount++;    //해당 인카운터를 몇 번 진행했는가?
        object reward = options[optionIndex].reward;

        if (reward is int) {         //자료형이 int라면 (스탯을 위한 자료형이 필요)
            Debug.Log($"스탯이 {reward}만큼 올랐습니다. \n({completeCount}번 진행)");
        }
        else if(reward is string) { //자료형이 string이라면 (아이템을 위한 자료형이 필요)
            Debug.Log($"아이템 \"{reward}\"을(를) 얻었습니다. \n({completeCount}번 진행)");
        }
    }
}

public class Episode   //인카운터가 모여 에피소드를 이루고, 에피소드가 모여 게임스토리를 이루는 구조를 계획 중
{
    public List<Encounter> episode = new List<Encounter>();

    public List<Encounter> PossibleEpisode  //선행조건을 만족한 인카운터만 추출
    {
        get { return episode.Where(ep => ep.precondition).ToList(); }
    }

    public Encounter GetRandomEncounter     //선행조건을 만족한 인카운터 중 랜덤으로 하나 뽑기
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

        episode.Add(newEncounter);  //에피소드에 인카운터 추가
    }
}
