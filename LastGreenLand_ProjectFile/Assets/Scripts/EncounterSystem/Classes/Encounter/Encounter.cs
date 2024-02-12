using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ��� ��ī������ �θ�Ŭ����
/// </summary>
public class Encounter
{
    /// <summary>
    /// ���� ���� // �ش� ��ī���͸� ������ �ڰ��� �ִ°�?
    /// </summary>
    public bool precondition; 

    /// <summary>
    /// ��ī���� ���� // ���� ���� Ȯ��
    /// </summary>
    public virtual void Encount()
    {
        if (!precondition) return;
    }

    /// <summary>
    /// ��ī���� ���� // �ƹ� ��� ����
    /// </summary>
    public virtual void Complete() { }
}
