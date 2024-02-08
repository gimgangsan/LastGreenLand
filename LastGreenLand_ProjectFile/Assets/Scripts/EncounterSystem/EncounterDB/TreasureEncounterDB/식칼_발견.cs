public class ½ÄÄ®_¹ß°ß : Treasure_Encounter
{
    public ½ÄÄ®_¹ß°ß()
    {
        precondition = true;
    }

    public override void Complete()
    {
        base.Complete();
        new RewardItem("½ÄÄ®").GetReward();
    }
}