using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scenario   //인카운터가 모여 시나리오를 이루고, 시나리오가 모여 게임스토리를 이루는 구조를 계획 중
{
    public string name;
    public List<Encounter> scenario = new List<Encounter>();

    public List<Encounter> PossibleScenario  //선행조건을 만족한 인카운터만 추출
    {
        get { return scenario.Where(encounter => encounter.precondition).ToList(); ; }
    }

    public Encounter GetRandomEncounter     //선행조건을 만족한 인카운터 중 랜덤으로 하나 뽑기
    {
        get
        {
            List<Encounter> possibleScenario = PossibleScenario;
            if (possibleScenario.Count == 0) return null;
            return possibleScenario[Random.Range(0, possibleScenario.Count)];
        }
    }

    public Scenario(params Encounter[] encounters)
    {
        foreach (Encounter encounter in encounters)
            scenario.Add(encounter);
    }


}
