using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//��ī���� �ý����� �����ϱ� ���� �ڷ������� ��Ƴ���
public class Encounter
{
    //��ó��
    public bool precondition;   //���� ����, �ش� ��ī���͸� ������ �ڰ��� �ִ°�?
    protected string beforeContext;      //��ī���Ϳ� ���� ��Ȳ ����, �Ǵ� ��ī���Ͱ� �߻��� �ƶ�

    public virtual void Encount()
    {
        if (!precondition) return;
        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);
    }

    public virtual void Complete() { }
}
