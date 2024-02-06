using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Encounter : Encounter
{
    public struct Option    //선택지 구조체
    {
        public string optionScript;   //선택지에 들어갈 대사
        public string afterContext;
        public object reward;   //무슨 자료형이 들어갈지 모름, is 연산자로 처리할 예정, 스탯 및 아이템을 위한 자료형이 필요
        public Encounter afterEncounter;

        public Option(string optionScript, string afterContext, object reward = null, Encounter afterEncounter = null)
        {
            this.optionScript = optionScript;
            this.reward = reward;
            this.afterContext = afterContext;
            this.afterEncounter = afterEncounter;
        }
    }
    Option[] options;    //선택지

    public Selection_Encounter(string name, bool precondition, string beforeContext, Option[] options)
        :base(name, precondition, beforeContext)
    {
        this.options = options;
    }

    public override void Encount()
    {
        base.Encount();
        
        for (int i = 0; i < EncounterManager.Instance.panelTexts.Length; i++)
        {
            if (i < options.Length) //선택지 개수만큼
            {
                EncounterManager.Instance.panelObjs[i].SetActive(true);                  //선택지 활성화
                EncounterManager.Instance.panelTexts[i].text = options[i].optionScript;  //텍스트 갱신
            }
            else
            {
                EncounterManager.Instance.panelObjs[i].SetActive(false);  //선택지 개수보다 많은 건 비활성화
            }
        }
    }

    public void Select(int optionIndex)
    {
        Option selectedOption = options[optionIndex];
       
        base.afterContext= selectedOption.afterContext;
        base.afterEncounter = selectedOption.afterEncounter;
        base.reward = selectedOption.reward;

        foreach (GameObject panel in EncounterManager.Instance.panelObjs)
            panel.SetActive(false);

        Debug.Log(afterContext);
        LogManager.Instance.AddLog(afterContext);
        base.Complete();
    }
}
