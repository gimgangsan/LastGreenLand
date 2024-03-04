using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusFormat", menuName = "ScriptableObject/Contents/Status")]
public class StatusFormat : ContentsFormat
{
    public int stat;

    public StatusFormat(Sprite sprite, string info, string description, int stat)
    {
        this.Sprite = sprite;
        this.Info = info;
        this.Description = description;
        this.stat = stat;
    }
}
