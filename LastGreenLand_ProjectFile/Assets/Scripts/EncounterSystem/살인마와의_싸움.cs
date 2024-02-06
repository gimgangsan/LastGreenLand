using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 살인마와의_싸움 : Battle_Encounter
{
    public 살인마와의_싸움(string name, bool precondition, string beforeContext, object reward) : base(name, precondition, beforeContext, reward)
    {
        base.name = "살인마와의 싸움";
        base.precondition = true;
        base.beforeContext = "살인마와 싸워 승리했습니다.";
        base.reward = 5;    //없앨 부분
    }
/*
    public override void WinBattle()
    {
        //스탯증가
    }*/
}

public class 시체와의_싸움 : Battle_Encounter
{
    public 시체와의_싸움(string name, bool precondition, string beforeContext, object reward) : base(name, precondition, beforeContext, reward)
    {
        base.name = "시체와의 싸움";
        base.precondition = true;
        base.beforeContext = "시체와 싸워 승리했습니다.";
        base.reward = "장검" ;    //없앨 부분
    }
/*
    public override void WinBattle()
    {
        //아이템 획득
    }*/
}