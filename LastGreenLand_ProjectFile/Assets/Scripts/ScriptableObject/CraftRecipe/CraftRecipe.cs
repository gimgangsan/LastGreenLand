using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftRecipe", menuName = "ScriptableObject/CraftRecipe")]
public class CraftRecipe : ScriptableObject
{
    public List<Ingridient> Recipe;
}

[Serializable]
public struct Ingridient
{
    public int ItemId;
    public int Quantitiy;
}
