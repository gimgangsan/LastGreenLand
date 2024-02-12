using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 모든 인카운터의 부모클래스
/// </summary>
public class Encounter
{
    /// <summary>
    /// 선행 조건 // 해당 인카운터를 진행할 자격이 있는가?
    /// </summary>
    public bool precondition; 

    /// <summary>
    /// 인카운터 시작 // 선행 조건 확인
    /// </summary>
    public virtual void Encount()
    {
        if (!precondition) return;
    }

    /// <summary>
    /// 인카운터 종료 // 아무 기능 없음
    /// </summary>
    public virtual void Complete() { }
}
