using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Encounter : Encounter
{
    protected string beforeContext;     // 인카운터에 대한 상황 설명, 또는 인카운터가 발생한 맥락

    public struct Option    //선택지 구조체
    {
        public string optionScript;         // 선택지에 들어갈 대사
        public string afterContext;         // 선택 이후의 상황 (경우에 따라 없을 수도)
        public IGetReward reward;           // 선택에 따른 보상 (경우에 따라 없을 수도)
        public Encounter afterEncounter;    // 이어질 인카운터 (경우에 따라 없을 수도)

        public Option(string optionScript, string afterContext = null, IGetReward reward = null, Encounter afterEncounter = null)
        {
            this.optionScript = optionScript;
            this.reward = reward;
            this.afterContext = afterContext;
            this.afterEncounter = afterEncounter;
        }
    }
    protected Option[] options;    //선택지

    public override void Encount()
    {
        base.Encount();
        SelectionManager.Instance.ongoingEncounter = this;  // 진행 중인 인카운터가 있음을 알리기 위해

        // beforeContext에 대한 로그 출력
        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);

        // 선택지 패널UI 활성화 & 텍스트 변경
        for (int i = 0; i < SelectionManager.Instance.panelTexts.Length; i++)
        {
            if (i < options.Length) //선택지 개수만큼
            {
                SelectionManager.Instance.panelObjs[i].SetActive(true);                  //패널UI 활성화
                SelectionManager.Instance.panelTexts[i].text = options[i].optionScript;  //텍스트 갱신
            }
            else    //선택지 개수보다 많은 것
            {
                SelectionManager.Instance.panelObjs[i].SetActive(false);
            }
        }
    }

    // 선택함 (SelectionManager에서 호출)
    public void Select(int optionIndex)
    {
        base.Complete();
        SelectionManager.Instance.ongoingEncounter = null;  // 진행 중인 인카운터가 없음을 알리기 위해

        // 패널UI 비활성화
        foreach (GameObject panel in SelectionManager.Instance.panelObjs)
            panel.SetActive(false);

        // 선택에 따른 결과 처리
        Option selectedOption = options[optionIndex];   // 선택한 것
        if(selectedOption.afterContext !=  null)        // afterContext가 있다면 로그 출력
        {
            Debug.Log(selectedOption.afterContext);
            LogManager.Instance.AddLog(selectedOption.afterContext);
        }
        selectedOption.reward?.GetReward();             // 보상이 있다면 획득
        selectedOption.afterEncounter?.Encount();       // 이어질 인카운터가 있다면 실행
    }
}
