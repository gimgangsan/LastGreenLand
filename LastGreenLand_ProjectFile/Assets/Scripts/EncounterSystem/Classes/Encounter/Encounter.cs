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
    public bool precondition;   //선행 조건, 해당 인카운터를 진행할 자격이 있는가?
    protected string beforeContext;      //인카운터에 대한 상황 설명, 또는 인카운터가 발생한 맥락

    public virtual void Encount()
    {
        if (!precondition) return;
        Debug.Log(beforeContext);
        LogManager.Instance.AddLog(beforeContext);
    }

    public virtual void Complete() { }
}
