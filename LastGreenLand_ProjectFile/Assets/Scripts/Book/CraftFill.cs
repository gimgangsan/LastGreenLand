using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftFill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _ingredientFill;
    [SerializeField] private GameObject _verticalLayout;

    [SerializeField] protected RectTransform display;
    [SerializeField] protected Image image;
    [SerializeField] protected TextMeshProUGUI info;
    [SerializeField] protected TextMeshProUGUI description;
    [SerializeField] protected TextMeshProUGUI statText;
    [SerializeField] private CraftRecipe _recipeFormat;
    private int stat = 999;
    private float descriptionMinimumHeight;

    public CraftRecipe RecipeFormat
    {
        get { return _recipeFormat; }
        set
        {
            _recipeFormat = value;
            ApplyContentsFormat(_recipeFormat);
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

    private void Awake()
    {
        descriptionMinimumHeight = display.rect.height;
        ApplyContentsFormat(_recipeFormat);
    }

    public void ApplyContentsFormat(CraftRecipe format)
    {
        if (format == null) return;
        _recipeFormat = format;
        info.text = _recipeFormat.Output.Item.Name;
        Stat = _recipeFormat.Output.Quantitiy;
        if (_recipeFormat.Output.Item.Sprite != null) image.sprite = _recipeFormat.Output.Item.Sprite;
        ChangeDescription(_recipeFormat.Output.Item.Describtion);
        DisplayIngredient(_recipeFormat.Recipe);
        AdjustHeight();
    }

    public void AdjustHeight()
    {
        if (_recipeFormat == null) return;
        RectTransform myRect = gameObject.GetComponent<RectTransform>();
        myRect.sizeDelta = new Vector2(myRect.rect.width, _recipeFormat.Recipe.Count * 24 + 30);
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

    public void DisplayIngredient(List<ManyItems> recipe)
    {
        for(int i = 0; i < recipe.Count; i++)
        {
            GameObject newIngridientDisplay = Instantiate(_ingredientFill);
            IngredientFill script = newIngridientDisplay.GetComponent<IngredientFill>();
            script.ShowIngredient(recipe[i]);
            newIngridientDisplay.transform.SetParent(_verticalLayout.transform, false);
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
