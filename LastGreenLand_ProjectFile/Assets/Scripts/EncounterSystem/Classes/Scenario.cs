using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ��ī���͵��� �����ϴ� Ŭ����
/// </summary>
public class Scenario
{
    public List<Encounter> scenario = new List<Encounter>();

    /// <summary>
    /// ���������� ������ ��ī���͸� ����
    /// </summary>
    public List<Encounter> PossibleScenario
    {
        get { return scenario.Where(encounter => encounter.precondition).ToList(); }
    }

    /// <summary>
    /// ���������� ������ ��ī���� �� �������� �ϳ� �̱� (������ null)
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
    /// �ߴ��� �Ǵ� ��ī��Ʈ�� �Է�
    /// </summary>
    public Scenario(params Encounter[] encounters)
    {
        foreach (Encounter encounter in encounters)
            scenario.Add(encounter);
    }


}
