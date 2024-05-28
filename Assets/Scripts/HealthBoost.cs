public class HealthBoost : PlayerDecorator
{
    private int bonusHealth;

    public HealthBoost(IPlayer player, int healthBonus) : base(player)
    {
        bonusHealth = healthBonus;
    }

    public override void ApplyBoost()
    {
        base.ApplyBoost();
        Health += bonusHealth; // Increase health by the bonus amount
    }
}
