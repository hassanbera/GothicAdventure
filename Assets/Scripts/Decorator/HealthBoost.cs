using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HealthBoost : PlayerDecorator
{
    private float bonusHealth;


    public HealthBoost(IPlayer player, float healthBonus) : base(player)
    {
        bonusHealth = healthBonus;
     
    }

    public override void ApplyBoost()
    {
        base.ApplyBoost();
        Health += bonusHealth;
    }
}
