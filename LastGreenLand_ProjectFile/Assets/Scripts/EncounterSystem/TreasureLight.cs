using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureLight : MonoBehaviour
{
    public GameObject star;
    public GameObject burst;
    public Treasure_Encounter parentEncounter;

    void OnEnable()
    {
        star.SetActive(true);
        burst.SetActive(false);
    }

    void OnMouseDown()
    {
        star.SetActive(false);
        burst.SetActive(true);
        parentEncounter.Complete();
        StartCoroutine(SetDisable());
    }

    IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
