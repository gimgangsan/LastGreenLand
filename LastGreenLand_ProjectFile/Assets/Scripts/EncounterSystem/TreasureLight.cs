using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureLight : MonoBehaviour
{
    public GameObject star;             // (자식 오브젝트)
    public GameObject burst;            // (자식 오브젝트)
    public System.Action CompleteEncounter;    // 클릭 했을 때 벌어질 일, (Treasure_Encounter에서 할당 받음)

    void OnEnable()
    {
        // 탐사 배경을 부모 오브젝트로
        transform.SetParent(TreasureManager.Instance.Background.transform);

        // 위치 변경
        Vector2 backgroundSize = TreasureManager.Instance.Background.GetComponent<SpriteRenderer>().sprite.bounds.size; // 탐사 배경의 크기
        transform.localPosition = new Vector3(backgroundSize.x * Random.Range(-0.4f, 0.4f),
                                              backgroundSize.y * Random.Range(-0.4f, 0.4f),
                                              0);

        star.SetActive(true);
        burst.SetActive(false);

        Explore.OnExplore.AddListener(() => Destroy(gameObject));   // 탐사 진행 시, 찾지 않은 보물은 사라짐
    }

    void OnMouseDown()
    {
        star.SetActive(false);
        burst.SetActive(true);

        CompleteEncounter?.Invoke();    // Treasure_Encounter에서 할당 받음

        StartCoroutine(SetDisable());
    }

    IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(1); // 파티클이 보여질 시간을 확보하기 위해
        Destroy(gameObject);
    }
}
