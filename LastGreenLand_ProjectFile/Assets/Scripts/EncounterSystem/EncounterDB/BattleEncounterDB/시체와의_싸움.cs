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
        new RewardStat((StatusPage.ContentsIndex.strength, 1)).GetReward();
    }
}