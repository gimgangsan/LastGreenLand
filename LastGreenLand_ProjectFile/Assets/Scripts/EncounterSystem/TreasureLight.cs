using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureLight : MonoBehaviour
{
    public GameObject star;             // (�ڽ� ������Ʈ)
    public GameObject burst;            // (�ڽ� ������Ʈ)
    public System.Action CompleteEncounter;    // Ŭ�� ���� �� ������ ��, (Treasure_Encounter���� �Ҵ� ����)

    void OnEnable()
    {
        // Ž�� ����� �θ� ������Ʈ��
        transform.SetParent(TreasureManager.Instance.Background.transform);

        // ��ġ ����
        Vector2 backgroundSize = TreasureManager.Instance.Background.GetComponent<SpriteRenderer>().sprite.bounds.size; // Ž�� ����� ũ��
        transform.localPosition = new Vector3(backgroundSize.x * Random.Range(-0.4f, 0.4f),
                                              backgroundSize.y * Random.Range(-0.4f, 0.4f),
                                              0);

        star.SetActive(true);
        burst.SetActive(false);

        Explore.OnExplore.AddListener(() => Destroy(gameObject));   // Ž�� ���� ��, ã�� ���� ������ �����
    }

    void OnMouseDown()
    {
        star.SetActive(false);
        burst.SetActive(true);

        CompleteEncounter?.Invoke();    // Treasure_Encounter���� �Ҵ� ����

        StartCoroutine(SetDisable());
    }

    IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(1); // ��ƼŬ�� ������ �ð��� Ȯ���ϱ� ����
        Destroy(gameObject);
    }
}
