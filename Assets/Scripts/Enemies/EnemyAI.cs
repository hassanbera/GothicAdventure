using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed = 2.0f;
    public float detectionRange = 10.0f;
    public float attackRange = 3.0f;
    public float distanceToPlayer;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        // Find the player with the tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

            if (distanceToPlayer < detectionRange){
                if (distanceToPlayer < attackRange){
                    // Attack the player
                    isAttacking = true;
                    animator.SetBool("isAttacking", true);
                    animator.SetBool("isRunning", false);
                }

                else{
                    // Move towards the player
                    isAttacking = false;
                    animator.SetBool("isAttacking", false);
                    animator.SetBool("isRunning", true);

                    Vector3 direction = player.transform.position - transform.position;
                    direction.y = 0; // Ignore y-axis movement
                    direction.z = 0; // Ignore z-axis movement

                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);

                    // Flip the sprite based on direction
                    spriteRenderer.flipX = direction.x < 0;
                }
            }
            
            else{
                // Player is out of detection range
                isAttacking = false;
                animator.SetBool("isAttacking", false);
                animator.SetBool("isRunning", false);
            }
        }
    }
}
