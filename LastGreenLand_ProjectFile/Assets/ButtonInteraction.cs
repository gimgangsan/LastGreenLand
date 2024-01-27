using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    private Color idleColor;
    [SerializeField] private Color highlightColor;
    [SerializeField] private Color holdColor;
    private SpriteRenderer sprite;
    public UnityEvent OnClick;

    bool mouseOnButton;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        idleColor = sprite.color;
    }

    private void OnMouseEnter()
    {
        sprite.color = highlightColor;
        mouseOnButton = true;
    }

    private void OnMouseExit()
    {
        sprite.color = idleColor;
        mouseOnButton = false;
    }

    private void OnMouseDown()
    {
        sprite.color = holdColor;
    }

    private void OnMouseUp()
    {
        sprite.color = (mouseOnButton)? highlightColor : idleColor;
        if (mouseOnButton) ExecuteWhenClicked();
    }

    public virtual void ExecuteWhenClicked()
    {
        OnClick.Invoke();
        Debug.Log("click");
    }
}
