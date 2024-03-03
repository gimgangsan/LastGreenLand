using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContentsFill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform display;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI info;
    [SerializeField] private TextMeshProUGUI description;
    public ContentsFormat contentsFormat;

    private float descriptionMinimumHeight;

    private void Awake()
    {
        descriptionMinimumHeight = display.rect.height;
        ApplyContentsFormat();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        display.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        display.gameObject.SetActive(false);
    }

    public void ApplyContentsFormat()
    {
        if (contentsFormat == null) return;
        ChangeDescription(contentsFormat.Description);
        info.text = contentsFormat.Info;
        if (contentsFormat.Sprite != null) image.sprite = contentsFormat.Sprite;
    }

    public void ChangeDescription(string newDescription)
    {
        description.text = newDescription;
        float newPreferredHeight = description.preferredHeight;
        if(descriptionMinimumHeight < newPreferredHeight)
        {
            display.sizeDelta = new Vector2(0, description.preferredHeight);
        }
        else
        {
            display.sizeDelta = new Vector2(0, descriptionMinimumHeight);
        }
    }
}
