public class ��Į_�߰� : Treasure_Encounter
{
    public ��Į_�߰�()
    {
        precondition = true;
    }

    public override void Complete()
    {
        base.Complete();
        new RewardItem("��Į").GetReward();
    }
}