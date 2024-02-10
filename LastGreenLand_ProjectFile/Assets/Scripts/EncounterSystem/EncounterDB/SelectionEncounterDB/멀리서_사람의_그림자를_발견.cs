using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 멀리서_사람의_그림자를_발견 : Selection_Encounter
{
    public 멀리서_사람의_그림자를_발견()
    {
        precondition = true;
        beforeContext = "멀리서 한 사람의 그림자가 보였습니다. 얼마만에 만나는 사람인가? 반가운 마음에 손을 흔들며 소리쳤습니다.\n" +
                        "\"저기요!\"\n" +
                        "그 소리를 들었는지, 그 사람이 뒤를 돌아 걸어옵니다. 그런데 걸음거리가 이상합니다.\n" +
                        "<color=green>(걸음걸이가 어떤가요?)</color>";
        options = new Option[]
        {
            new (optionScript: "달려온다",
                 reward: new RewardStat((StatusPage.ContentsIndex.maxhp, 10)),
                 afterEncounter: new 달려오는_사람()),
            new (optionScript: "절뚝거린다",
                 afterContext: "그 사람이 절뚝거리며 걸어옵니다. 다리를 다친 듯 합니다.",
                 reward: new RewardItem("붕대")),
            new (optionScript: "춤추며 온다",
                 afterContext: "그 사람이 춤추며 다가옵니다. 소중한 사람을 잃어 미처버리는 건 종종 있는 일입니다.") 
        };
    }
}