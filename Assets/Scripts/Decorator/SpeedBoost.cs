using UnityEngine;
using System.Collections;


public class SpeedBoost : PlayerDecorator
{
    private int bonusSpeed;

    public SpeedBoost(IPlayer player, int bonusSpeed) : base(player)
    {
        this.bonusSpeed = bonusSpeed;
    }

    public override void ApplyBoost()
    {
        base.ApplyBoost();
        Speed += bonusSpeed; // Increase health by the bonus amount
    }
}
