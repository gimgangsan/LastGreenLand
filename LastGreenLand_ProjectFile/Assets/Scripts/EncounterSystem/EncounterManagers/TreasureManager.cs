using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;


//EncounterSystem.cs���� �а� �� ��
public class TreasureManager : MonoBehaviour
{
    public GameObject treasureLightPrefab;
    public GameObject Background;

    public List<Treasure_Encounter> ongoingEncounters = new();

    public Scenario �׽�Ʈ�ó����� = new Scenario(
        new ����_�ܰ�_�߰�(),
        new ��Į_�߰�()
    );

    //�̱��� ����
    public static TreasureManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;    //�̱��� ����
    }

    public void Encount()
    {
        int rand = Random.Range(1, 4);
        for (int i = 0; i < rand; i++)
            �׽�Ʈ�ó�����.GetRandomEncounter.Encount();
    }
}
