using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EncounterDB
{

    #region Encounter
    public static Battle_Encounter 살인마와의_싸움 = new Battle_Encounter(
        name: "살인마와의 싸움",
        precondition: true,
        beforeContext: "살인마와 싸워 승리했습니다.",
        reward: 5
        );

    public static Battle_Encounter 시체와의_싸움 = new Battle_Encounter(
        name: "시체와의 싸움",
        precondition: true,
        beforeContext: "시체와 싸워 승리했습니다.",
        reward: 1
        );

    public static Selection_Encounter 달려오는_사람 = new Selection_Encounter(
        name: "달려오는_사람",
        precondition: true,
        beforeContext: "<color=green>(무엇이 보였나요?)</color>",
        options: new Selection_Encounter.Option[] {
            new(optionScript: "피 묻은 칼",
                afterContext: "그 사람은 손에 피 묻은 칼을 들고 있었습니다!",
                afterEncounter: 살인마와의_싸움),
            new(optionScript: "찢어진 옷",
                afterContext: "찢어진 옷 사이로 보이는 구더기와 썩은 냄새가 얼굴을 찌푸리게 만듭니다.",
                afterEncounter: 시체와의_싸움
                ) }
        );

    public static Selection_Encounter 멀리서_사람의_그림자를_발견 = new Selection_Encounter(
        name: "멀리서 사람의 그림자를 발견",
        precondition: true,
        beforeContext: "멀리서 한 사람의 그림자가 보였습니다. 얼마만에 만나는 사람인가? 반가운 마음에 손을 흔들며 소리쳤습니다.\n" +
                       "\"저기요!\"\n" +
                       "그 소리를 들었는지, 그 사람이 뒤를 돌아 걸어옵니다. 그런데 걸음거리가 이상합니다.\n" +
                       "<color=green>(걸음걸이가 어떤가요?)</color>",
        options: new Selection_Encounter.Option[] {
            new (optionScript: "달려온다",
                 afterContext: "그 사람이 달려옵니다. 거리가 급격히 가까워졌습니다. 그에 따라, 전에는 볼 수 없었던 것까지 보였습니다.\n",
                 reward: 1,
                 afterEncounter: 달려오는_사람
                ),
            new (optionScript: "절뚝거린다",
                 afterContext: "그 사람이 절뚝거리며 걸어옵니다. 다리를 다친 듯 합니다."
                ),
            new (optionScript: "춤추며 온다",
                 afterContext: "그 사람이 춤추며 다가옵니다. 소중한 사람을 잃어 미처버리는 건 종종 있는 일입니다.") }
        );

    public static Treasure_Encounter 낡은_단검_발견 = new Treasure_Encounter(
        name: "낡은 단검 발견",
        precondition: true,
        beforeContext: "근처에 빛나는 물건이 보입니다.",
        reward: "낡은 단검"
        );

    public static Treasure_Encounter 식칼_발견 = new Treasure_Encounter(
        name: "식칼 발견",
        precondition: true,
        beforeContext: "근처에 빛나는 물건이 보입니다.",
        reward: "식칼"
        );
    #endregion

    public static Scenario 테스트시나리오 = new Scenario(
        멀리서_사람의_그림자를_발견,
        낡은_단검_발견,
        식칼_발견
        );
}
