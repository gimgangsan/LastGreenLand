public class 달려오는_사람 : Selection_Encounter
{
    public 달려오는_사람()
    {
        precondition = true;
        beforeContext = "그 사람이 달려옵니다. 거리가 급격히 가까워졌습니다. 그에 따라, 전에는 볼 수 없었던 것까지 보였습니다.\n" +
                        "<color=green>(무엇이 보였나요?)</color>";
        options = new Option[]
        {
            new(optionScript: "피 묻은 칼",
                afterContext: "그 사람은 손에 피 묻은 칼을 들고 있었습니다!",
                afterEncounter: new 살인마와의_싸움()),
            new(optionScript: "찢어진 옷",
                afterContext: "찢어진 옷 사이로 보이는 구더기와 썩은 냄새가 얼굴을 찌푸리게 만듭니다.",
                afterEncounter: new 시체와의_싸움())
        };
    }
}