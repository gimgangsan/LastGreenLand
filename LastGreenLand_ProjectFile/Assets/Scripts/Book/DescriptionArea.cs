using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DescriptionArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject display;
    [SerializeField] private GameObject displayMinimal;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] [TextArea(2,8)] private string description;

    private void Awake()
    {
        ChangeDescription(description);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        display.SetActive(true);
        displayMinimal.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        display.SetActive(false);
        displayMinimal.SetActive(false);
    }

    public void ChangeDescription(string description)
    {
        text.text = description;
    }
}
