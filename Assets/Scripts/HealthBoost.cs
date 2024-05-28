// HealthBoost.cs
public class HealthBoost : PlayerDecorator
{
    public HealthBoost(IPlayer player) : base(player) { }

    public override void ApplyBoost()
    {
        base.ApplyBoost();
        Health += 50; // Increase health by 50
    }
}

// ShieldBoost.cs
public class ShieldBoost : PlayerDecorator
{
    public ShieldBoost(IPlayer player) : base(player) { }

    public override void ApplyBoost()
    {
        base.ApplyBoost();
        // Implement shield logic
    }
}
