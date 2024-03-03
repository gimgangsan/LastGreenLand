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
    [SerializeField] protected TextMeshProUGUI stat;
    private StatusFormat contentsFormat;

    public StatusFormat ContentsFormat
    {
        get { return contentsFormat; }
        set
        {
            contentsFormat = value;
            ApplyContentsFormat();
        }
    }

    public int Stat
    {
        get { return contentsFormat.stat; }
        set
        {
            contentsFormat.stat = value;
            stat.text = contentsFormat.stat.ToString();
        }
    }

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

    public virtual void ApplyContentsFormat()
    {
        if (contentsFormat == null) return;
        ChangeDescription(contentsFormat.Description);
        info.text = contentsFormat.Info;
        stat.text = contentsFormat.stat.ToString();
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
}
