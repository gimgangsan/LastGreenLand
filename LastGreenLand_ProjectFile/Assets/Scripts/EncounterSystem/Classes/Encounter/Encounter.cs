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

    public virtual void Encount()
    {
        if (!precondition) return;
    }

    public virtual void Complete() { }
}
