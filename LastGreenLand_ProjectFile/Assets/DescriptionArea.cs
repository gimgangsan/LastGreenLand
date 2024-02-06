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
    [SerializeField] private string description;
    [SerializeField] GraphicRaycaster gr;

    private void Awake()
    {
        display.GetComponent<TextMeshProUGUI>().text = description;
        display.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        display.SetActive(true);
        
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Debug.DrawRay(ray.origin, ray.direction*100, Color.red, 1);

        List<RaycastResult> hits = new();
        //EventSystem.current.RaycastAll(eventData, hits);
        gr.Raycast(eventData, hits);
        
        foreach (RaycastResult hit in hits)
            display.transform.position = hit.worldPosition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        display.SetActive(false);
    }
}
