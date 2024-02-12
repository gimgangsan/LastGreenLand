using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Encounter : Encounter
{
    protected string beforeContext;     // ��ī���Ϳ� ���� ��Ȳ ����, �Ǵ� ��ī���Ͱ� �߻��� �ƶ�

    public struct Option    //������ ����ü
    {
        public string optionScript;         // �������� �� ���
        public string afterContext;         // ���� ������ ��Ȳ (��쿡 ���� ���� ����)
        public IGetReward reward;           // ���ÿ� ���� ���� (��쿡 ���� ���� ����)
        public Encounter afterEncounter;    // �̾��� ��ī���� (��쿡 ���� ���� ����)

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
        SelectionManager.Instance.ongoingEncounter = this;  // ���� ���� ��ī���Ͱ� ������ �˸��� ����

        // beforeContext�� ���� �α� ���
        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);

        // ������ �г�UI Ȱ��ȭ & �ؽ�Ʈ ����
        for (int i = 0; i < SelectionManager.Instance.panelTexts.Length; i++)
        {
            if (i < options.Length) //������ ������ŭ
            {
                SelectionManager.Instance.panelObjs[i].SetActive(true);                  //�г�UI Ȱ��ȭ
                SelectionManager.Instance.panelTexts[i].text = options[i].optionScript;  //�ؽ�Ʈ ����
            }
            else    //������ �������� ���� ��
            {
                SelectionManager.Instance.panelObjs[i].SetActive(false);
            }
        }
    }

    // ������ (SelectionManager���� ȣ��)
    public void Select(int optionIndex)
    {
        base.Complete();
        SelectionManager.Instance.ongoingEncounter = null;  // ���� ���� ��ī���Ͱ� ������ �˸��� ����

        // �г�UI ��Ȱ��ȭ
        foreach (GameObject panel in SelectionManager.Instance.panelObjs)
            panel.SetActive(false);

        // ���ÿ� ���� ��� ó��
        Option selectedOption = options[optionIndex];   // ������ ��
        if(selectedOption.afterContext !=  null)        // afterContext�� �ִٸ� �α� ���
        {
            Debug.Log(selectedOption.afterContext);
            LogManager.Instance.AddLog(selectedOption.afterContext);
        }
        selectedOption.reward?.GetReward();             // ������ �ִٸ� ȹ��
        selectedOption.afterEncounter?.Encount();       // �̾��� ��ī���Ͱ� �ִٸ� ����
    }
}
