using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Encounter : Encounter
{
    public struct Option    //������ ����ü
    {
        public string optionScript;   //�������� �� ���
        public string afterContext;
        public object reward;   //���� �ڷ����� ���� ��, is �����ڷ� ó���� ����, ���� �� �������� ���� �ڷ����� �ʿ�
        public Encounter afterEncounter;

        public Option(string optionScript, string afterContext, object reward = null, Encounter afterEncounter = null)
        {
            this.optionScript = optionScript;
            this.reward = reward;
            this.afterContext = afterContext;
            this.afterEncounter = afterEncounter;
        }
    }
    Option[] options;    //������

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
            if (i < options.Length) //������ ������ŭ
            {
                EncounterManager.Instance.panelObjs[i].SetActive(true);                  //������ Ȱ��ȭ
                EncounterManager.Instance.panelTexts[i].text = options[i].optionScript;  //�ؽ�Ʈ ����
            }
            else
            {
                EncounterManager.Instance.panelObjs[i].SetActive(false);  //������ �������� ���� �� ��Ȱ��ȭ
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
