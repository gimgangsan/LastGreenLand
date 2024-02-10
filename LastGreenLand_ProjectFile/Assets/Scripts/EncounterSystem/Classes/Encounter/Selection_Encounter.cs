using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Encounter : Encounter
{
    protected string beforeContext;      //인카운터에 대한 상황 설명, 또는 인카운터가 발생한 맥락

    public struct Option    //선택지 구조체
    {
        public string optionScript;   //선택지에 들어갈 대사
        public string afterContext;
        public IGetReward reward;
        public Encounter afterEncounter;

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
        SelectionManager.Instance.ongoingEncounter = this;

        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);

        for (int i = 0; i < SelectionManager.Instance.panelTexts.Length; i++)
        {
            if (i < options.Length) //선택지 개수만큼
            {
                SelectionManager.Instance.panelObjs[i].SetActive(true);                  //선택지 활성화
                SelectionManager.Instance.panelTexts[i].text = options[i].optionScript;  //텍스트 갱신
            }
            else
            {
                SelectionManager.Instance.panelObjs[i].SetActive(false);  //선택지 개수보다 많은 건 비활성화
            }
        }
    }

    public void Select(int optionIndex)
    {
        base.Complete();
        SelectionManager.Instance.ongoingEncounter = null;

        foreach (GameObject panel in SelectionManager.Instance.panelObjs)
            panel.SetActive(false);

        Option selectedOption = options[optionIndex];
        if(selectedOption.afterContext !=  null)
        {
            Debug.Log(selectedOption.afterContext);
            LogManager.Instance.AddLog(selectedOption.afterContext);
        }
        selectedOption.reward?.GetReward();
        selectedOption.afterEncounter?.Encount();
    }
}
