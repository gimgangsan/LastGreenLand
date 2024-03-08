using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightExpand : MonoBehaviour
{
    [SerializeField] private RectTransform _target;
    private RectTransform _myRect;

    private void Awake()
    {
        _myRect = GetComponent<RectTransform>();
        _myRect.sizeDelta = new Vector2(_myRect.rect.width, _target.rect.height);
    }
}
