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
        Attack += bonusAttack; // Increase health by the bonus amount
        Debug.Log("Attack boosted by " + bonusAttack);
    }

}
