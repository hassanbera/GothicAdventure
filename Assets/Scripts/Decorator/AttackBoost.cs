using UnityEngine;
using System.Collections;

public class AttackBoost : PlayerDecorator
{
    private int bonusAttack;
    public AttackBoost(IPlayer player, int bonusAttack) : base(player)
    {
        this.bonusAttack = bonusAttack;

    }
    public override void ApplyBoost()
    {
        base.ApplyBoost();
        JumpForce += bonusAttack;

        Debug.Log("jump boosted to " + JumpForce);
    }

}
