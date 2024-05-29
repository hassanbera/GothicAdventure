using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    // Properties
    float Speed { get; set; }
    float Health { get; set; }
    float Damage { get; set; }
    GameObject Player { get; set; }
    float DetectionRange { get; set; }
    float AttackRange { get; set; }
    float DistanceToPlayer { get; set; }
    SpriteRenderer SpriteRenderer { get; set; }
    Animator Animator { get; set; }
    bool IsAttacking { get; set; }
    

    // Methods
    void Attack();
    void TakeDamage(float damage);
    void Die();
}