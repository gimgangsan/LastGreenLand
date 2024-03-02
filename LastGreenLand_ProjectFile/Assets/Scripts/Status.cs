using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public struct HP_struct
{
    public int hp;
    public int maxHp;

    public override readonly string ToString()
    {
        return hp + "/" + maxHp;
    }
}

[Serializable]
public class BattleStatus
{
    public HP_struct hp;
    public int str;
    public int def;
}