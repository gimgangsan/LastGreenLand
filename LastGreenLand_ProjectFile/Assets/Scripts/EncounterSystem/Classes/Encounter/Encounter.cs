using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Encounter
{
    //전처리
    public bool precondition;   //선행 조건, 해당 인카운터를 진행할 자격이 있는가?

    public virtual void Encount()
    {
        if (!precondition) return;
    }

    public virtual void Complete() { }
}
