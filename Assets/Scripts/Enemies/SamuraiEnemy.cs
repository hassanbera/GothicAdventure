using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiEnemy : MonoBehaviour, IEnemy
{
    // Properties
    public float Speed { get; set; } = 5;
    public float Health { get; set; } = 60;
    public float Damage { get; set; } = 10;

    public GameObject Player { get; set; }
    public float DetectionRange { get; set; } = 10;
    public float AttackRange { get; set; } = 3;
    public float DistanceToPlayer { get; set; }
    public SpriteRenderer SpriteRenderer { get; set; }
    public Animator Animator { get; set; }
    public bool IsAttacking { get; set; }

    
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Player != null)
        {
            DistanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);

            if (DistanceToPlayer < DetectionRange)
            {
                if (DistanceToPlayer < AttackRange)
                {
                    // Attack the player
                    IsAttacking = true;
                    Animator.SetBool("isAttacking", true);
                    Animator.SetBool("isRunning", false);
                }

                else
                {
                    // Move towards the player
                    IsAttacking = false;
                    Animator.SetBool("isAttacking", false);
                    Animator.SetBool("isRunning", true);

                    Vector3 direction = Player.transform.position - transform.position;
                    direction.y = 0; // Ignore y-axis movement
                    direction.z = 0; // Ignore z-axis movement

                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x, transform.position.y, transform.position.z), Speed * Time.deltaTime);

                    // Flip the sprite based on direction
                    SpriteRenderer.flipX = direction.x < 0;
                }
            }

            else
            {
                // Player is out of detection range
                IsAttacking = false;
                Animator.SetBool("isAttacking", false);
                Animator.SetBool("isRunning", false);
            }
        }
    }

    // Methods
    public void Attack()
    {
        Debug.Log("Knight Enemy is attacking!");
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Debug.Log("Knight Enemy took damage! Health: " + Health);

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Knight Enemy died!");
        Destroy(gameObject);

        FindObjectOfType<PlayerExperience>().ChangeExperience(80);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FallDetector")
        {
            Die();
        }
    }
}

