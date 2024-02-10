using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Encounter : Encounter
{
    protected string beforeContext;      //��ī���Ϳ� ���� ��Ȳ ����, �Ǵ� ��ī���Ͱ� �߻��� �ƶ�

    public struct Option    //������ ����ü
    {
        public string optionScript;   //�������� �� ���
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
    protected Option[] options;    //������

    public override void Encount()
    {
        base.Encount();
        SelectionManager.Instance.ongoingEncounter = this;

        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);

        for (int i = 0; i < SelectionManager.Instance.panelTexts.Length; i++)
        {
            if (i < options.Length) //������ ������ŭ
            {
                SelectionManager.Instance.panelObjs[i].SetActive(true);                  //������ Ȱ��ȭ
                SelectionManager.Instance.panelTexts[i].text = options[i].optionScript;  //�ؽ�Ʈ ����
            }
            else
            {
                SelectionManager.Instance.panelObjs[i].SetActive(false);  //������ �������� ���� �� ��Ȱ��ȭ
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
