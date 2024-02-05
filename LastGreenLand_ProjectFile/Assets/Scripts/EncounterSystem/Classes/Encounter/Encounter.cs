using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//인카운터 시스템을 구현하기 위한 자료형들을 모아놓음
public class Encounter
{
    //전처리
    public string name;         //각각의 인카운터는 List<Encounter>를 통해 관리되는데, 인덱스만으로는 인카운터가 무슨 내용인지 기억하기 어려우므로
    public bool precondition;   //선행 조건, 해당 인카운터를 진행할 자격이 있는가?
    public int completeCount;   //인카운터를 완료한 횟수
    protected string beforeContext;      //인카운터에 대한 상황 설명, 또는 인카운터가 발생한 맥락

    //후처리
    protected string afterContext;
    protected Encounter afterEncounter;
    protected object reward;

    protected Encounter(string name, bool precondition, string beforeContext)
    {
        this.name = name;
        this.precondition = precondition;
        this.beforeContext = beforeContext;
    }

    public virtual void Encount()
    {
        if (!precondition) return;
        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);
        EncounterManager.Instance.ongoingEncounter = this;
    }

    public virtual void Complete()
    {
        GetReward(reward);
        completeCount++;
        EncounterManager.Instance.ongoingEncounter = null;
        afterEncounter?.Encount();
    }

    void GetReward(object reward)   //reward 처리
    {
        if (reward is int) {         //자료형이 int라면 (스탯을 위한 자료형이 필요)
            Debug.Log($"스탯이 {reward}만큼 올랐습니다.");
            LogManager.Instance.AddLog($"스탯이 {reward}만큼 올랐습니다.");
        }
        else if(reward is string) { //자료형이 string이라면 (아이템을 위한 자료형이 필요)
            Debug.Log($"아이템 \"{reward}\"을(를) 얻었습니다.");
            LogManager.Instance.AddLog($"아이템 \"{reward}\"을(를) 얻었습니다.");
        }
    }
}
