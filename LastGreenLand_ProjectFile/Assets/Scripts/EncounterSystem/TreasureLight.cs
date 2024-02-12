using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureLight : MonoBehaviour
{
    public GameObject star;             // (�ڽ� ������Ʈ)
    public GameObject burst;            // (�ڽ� ������Ʈ)
    public Action CompleteEncounter;    // Ŭ�� ���� �� ������ ��, (Treasure_Encounter���� �Ҵ� ����)

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
        yield return new WaitForSeconds(1); // ��ƼŬ�� ������ �ð��� Ȯ���ϱ� ����
        Destroy(gameObject);
    }
}
