using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ContentsFormat", menuName = "ScriptableObject/Contents/Default")]
public class ContentsFormat : ScriptableObject
{
    public Sprite Sprite;
    public string Info;
    [TextArea(2, 8)] public string Description;
}
