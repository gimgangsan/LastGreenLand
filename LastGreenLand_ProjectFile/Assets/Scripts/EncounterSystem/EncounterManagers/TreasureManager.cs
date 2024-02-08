using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;


//EncounterSystem.cs먼저 읽고 올 것
public class TreasureManager : MonoBehaviour
{
    public GameObject treasureLightPrefab;
    public GameObject Background;

    public Treasure_Encounter ongoingEncounter;

    public Scenario 테스트시나리오 = new Scenario(
        new 낡은_단검_발견(),
        new 식칼_발견()
    );

    //싱글턴 패턴
    public static TreasureManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;    //싱글턴 패턴
    }
}
