using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 인카운터들을 관리하는 클래스
/// </summary>
public class Scenario
{
    public List<Encounter> scenario = new List<Encounter>();

    /// <summary>
    /// 선행조건을 만족한 인카운터만 추출
    /// </summary>
    public List<Encounter> PossibleScenario
    {
        get { return scenario.Where(encounter => encounter.precondition).ToList(); }
    }

    /// <summary>
    /// 선행조건을 만족한 인카운터 중 랜덤으로 하나 뽑기 (없으면 null)
    /// </summary>
    public Encounter GetRandomEncounter 
    {
        get
        {
            List<Encounter> possibleScenario = PossibleScenario;
            if (possibleScenario.Count == 0) return null;
            return possibleScenario[Random.Range(0, possibleScenario.Count)];
        }
    }

    /// <summary>
    /// 발단이 되는 인카운트만 입력
    /// </summary>
    public Scenario(params Encounter[] encounters)
    {
        foreach (Encounter encounter in encounters)
            scenario.Add(encounter);
    }


}
