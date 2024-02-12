using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureLight : MonoBehaviour
{
    public GameObject star;             // (자식 오브젝트)
    public GameObject burst;            // (자식 오브젝트)
    public Action CompleteEncounter;    // 클릭 했을 때 벌어질 일, (Treasure_Encounter에서 할당 받음)

    void OnEnable()
    {
        star.SetActive(true);
        burst.SetActive(false);
    }

    void OnMouseDown()
    {
        star.SetActive(false);
        burst.SetActive(true);

        CompleteEncounter?.Invoke();

        StartCoroutine(SetDisable());
    }

    IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(1); // 파티클이 보여질 시간을 확보하기 위해
        Destroy(gameObject);
    }
}
