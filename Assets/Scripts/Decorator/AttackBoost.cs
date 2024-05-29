using UnityEngine;
using System.Collections;

public class AttackBoost : PlayerDecorator
{
    private int bonusAttack;
    private float duration;

    public AttackBoost(IPlayer player, int bonusAttack, float duration) : base(player)
    {
        this.bonusAttack = bonusAttack;
        this.duration = duration;
    }

    public void Initialize(IPlayer player, int bonusAttack, float duration)
    {
        this.decoratedPlayer = player;
        this.bonusAttack = bonusAttack;
        this.duration = duration;
    }

    public override void ApplyBoost()
    {
        base.ApplyBoost();
        Attack += bonusAttack;
    }

}
