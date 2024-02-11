public class 시체와의_싸움 : Battle_Encounter
{
    public 시체와의_싸움()
    {
        precondition = true;
        beforeContext = "시체와의 싸움이 시작됩니다.";
    }

    public override void Complete()
    {
        base.Complete();
        new RewardStat(StatusPage.ContentsIndex.maxhp, 10).GetReward();
        new RewardStat(StatusPage.ContentsIndex.hp, 10).GetReward();
    }
}