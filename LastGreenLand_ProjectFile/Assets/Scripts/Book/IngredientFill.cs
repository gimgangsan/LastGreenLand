using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IngredientFill : MonoBehaviour
{
    [SerializeField] protected Image _image;
    [SerializeField] protected TextMeshProUGUI _info;
    [SerializeField] protected TextMeshProUGUI _statText;

    public void ShowIngredient(ManyItems ingredient)
    {
        if(ingredient.Item.Sprite != null) _image.sprite = ingredient.Item.Sprite;
        _info.text = ingredient.Item.Name;
        _statText.text = ingredient.Quantitiy.ToString();
    }
}
