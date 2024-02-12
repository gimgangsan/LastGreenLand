using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public GameObject treasureLightPrefab;
    public GameObject Background;   // 탐사 배경 (treasureLight의 위치를 조정하기 위해 사용)

    public Scenario 테스트시나리오 = new Scenario(
        new 낡은_단검_발견(),
        new 식칼_발견()
    );

    public static TreasureManager Instance { get; private set; }    //싱글턴 패턴

    void Awake()
    {
        Instance = this;    //싱글턴 패턴
    }

    public void Encount()
    {
        // 1~3개의 Treasure Encounter 생성
        int rand = Random.Range(1, 4);
        for (int i = 0; i < rand; i++)
            테스트시나리오.GetRandomEncounter.Encount();
    }
}
