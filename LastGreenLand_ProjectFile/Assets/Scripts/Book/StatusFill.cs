using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatusFill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected RectTransform display;
    [SerializeField] protected Image image;
    [SerializeField] protected TextMeshProUGUI info;
    [SerializeField] protected TextMeshProUGUI description;
    [SerializeField] protected TextMeshProUGUI statText;
    [SerializeField] private StatusFormat contentsFormat;
    private int stat = 999;

    public StatusFormat ContentsFormat
    {
        get { return contentsFormat; }
        set 
        { 
            contentsFormat = value;
            ApplyContentsFormat(contentsFormat);
        }
    }

    public int Stat
    {
        get { return stat; }
        set
        {
            stat = value;
            statText.text = stat.ToString();
        }
    }

    private float descriptionMinimumHeight;

    private void Awake()
    {
        descriptionMinimumHeight = display.rect.height;
        ApplyContentsFormat(contentsFormat);
    }

    public void ApplyContentsFormat(StatusFormat format)
    {
        if (format == null) return;
        contentsFormat = format;
        ChangeDescription(contentsFormat.Description);
        info.text = contentsFormat.Info;
        Stat = contentsFormat.stat;
        if (contentsFormat.Sprite != null) image.sprite = contentsFormat.Sprite;
    }

    public void ChangeDescription(string newDescription)
    {
        description.text = newDescription;
        float newPreferredHeight = description.preferredHeight;
        if (descriptionMinimumHeight < newPreferredHeight)
        {
            display.sizeDelta = new Vector2(0, description.preferredHeight);
        }
        else
        {
            display.sizeDelta = new Vector2(0, descriptionMinimumHeight);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        display.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        display.gameObject.SetActive(false);
    }
}
