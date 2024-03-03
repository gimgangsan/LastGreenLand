using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftRecipe", menuName = "ScriptableObject/CraftRecipe")]
public class CraftRecipe : ScriptableObject
{
    public List<ManyItems> Recipe;
    public ManyItems Output;
}

[Serializable]
public struct ManyItems
{
    public Item Item;
    public int Quantitiy;
}
