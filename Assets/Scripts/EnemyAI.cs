using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed = 1.0f;
    public float detectionRange = 10.0f;
    public float attackRange = 2.0f;
    public float distanceToPlayer;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            if (distanceToPlayer < detectionRange)
            {
                Vector3 direction = player.transform.position - transform.position;
                direction.y = 0; // Ignore y-axis movement
                direction.z = 0; // Ignore z-axis movement

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);

                // Flip the sprite based on direction
                if (direction.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }

                if(distanceToPlayer < attackRange)
                {
                    animator.SetBool("isAttacking", true);
                    animator.SetBool("isRunning", false);
                }
                else
                {
                    animator.SetBool("isAttacking", false);
                }

                animator.SetBool("isRunning", true);

            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }
}
