using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 반짝임을 찾는 인카운터
/// </summary>
public class Treasure_Encounter : Encounter
{
    /// <summary>
    /// 인카운터 시작 // TreasureLight프리팹 생성, 델리게이트 할당
    /// </summary>
    public override void Encount()
    {
        base.Encount();

        //프리팹 생성
        GameObject light = GameObject.Instantiate(TreasureManager.Instance.treasureLightPrefab);

        // 프리팹을 클릭 했을 때 벌어질 일
        light.GetComponent<TreasureLight>().CompleteEncounter = new Action(Complete);
    }

    /// <summary>
    /// 인카운터가 끝났을 때 호출 // 아무 기능 없음
    /// </summary>
    public override void Complete()
    {
        base.Complete();
    }
}
