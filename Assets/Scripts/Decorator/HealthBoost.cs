using UnityEngine;

public class HealthBoost : PlayerDecorator
{
    private int bonusHealth;
    private float duration;

    public HealthBoost(IPlayer player, int healthBonus, float duration) : base(player)
    {
        bonusHealth = healthBonus;
        this.duration = duration;
    }

    public override void ApplyBoost()
    {
        base.ApplyBoost();
        Health += bonusHealth;
        StartCoroutine(TemporaryBoost());
    }

    public override void RemoveBoost()
    {
        Health -= bonusHealth;
    }

    private IEnumerator TemporaryBoost()
    {
        yield return new WaitForSeconds(duration);
        RemoveBoost();
        Destroy(this); // Remove the decorator component after the boost duration
    }
}
