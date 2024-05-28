public class AttackBoost : PlayerDecorator
{
    private int bonusSpeed;

    public HealthBoost(IPlayer player, int bonusSpeed) : base(player)
    {
        this.bonusSpeed = bonusSpeed;
    }

    public override void ApplyBoost()
    {
        base.ApplyBoost();
        Speed += bonusSpeed; // Increase health by the bonus amount
    }
}
