using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInteration : ButtonInteraction
{
    [SerializeField] private Color toggleColor;
    private Color initColor;
    bool isSelected;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        initColor = sprite.color;
        idleColor = sprite.color;
    }

    public override void ExecuteWhenClicked()
    {
        base.ExecuteWhenClicked();
        ToggleColor();
    }

    public void ToggleColor()
    {
        if (isSelected)
        {
            isSelected = false;
            idleColor = initColor;
        }
        else
        {
            isSelected = true;
            idleColor = toggleColor;
        }
    }

    public void ToggleOff()
    {
        isSelected = false;
        idleColor = initColor;
        sprite.color = idleColor;
    }
}
