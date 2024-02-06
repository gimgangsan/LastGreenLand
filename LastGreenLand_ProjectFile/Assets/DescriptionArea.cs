using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DescriptionArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject display;
    [SerializeField] private string description;

    private void Awake()
    {
        display.GetComponent<TextMeshProUGUI>().text = description;
        display.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        display.SetActive(true);
        display.GetComponent<RectTransform>().position = new Vector3(0,0,0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        display.SetActive(false);
    }
}
