public class ��ü����_�ο� : Battle_Encounter
{
    public ��ü����_�ο�()
    {
        precondition = true;
        beforeContext = "��ü���� �ο��� ���۵˴ϴ�.";
    }

    public override void Complete()
    {
        base.Complete();
        new RewardStat(StatusPage.ContentsIndex.maxhp, 10).GetReward();
        new RewardStat(StatusPage.ContentsIndex.hp, 10).GetReward();
    }
}