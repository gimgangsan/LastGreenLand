using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    protected Color idleColor;
    [SerializeField] protected Color highlightColor;
    [SerializeField] protected Color holdColor;
    protected SpriteRenderer sprite;
    public UnityEvent OnClick;

    protected bool mouseOnButton;

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
        if (mouseOnButton) ExecuteWhenClicked();
        sprite.color = (mouseOnButton)? highlightColor : idleColor;
    }

    public virtual void ExecuteWhenClicked()
    {
        OnClick.Invoke();
        Debug.Log("click");
    }
}
