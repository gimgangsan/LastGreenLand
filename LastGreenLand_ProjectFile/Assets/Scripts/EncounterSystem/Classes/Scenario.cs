using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scenario   //��ī���Ͱ� �� �ó������� �̷��, �ó������� �� ���ӽ��丮�� �̷�� ������ ��ȹ ��
{
    public string name;
    public List<Encounter> scenario = new List<Encounter>();

    public List<Encounter> PossibleScenario  //���������� ������ ��ī���͸� ����
    {
        get { return scenario.Where(encounter => encounter.precondition).ToList(); ; }
    }

    public Encounter GetRandomEncounter     //���������� ������ ��ī���� �� �������� �ϳ� �̱�
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
