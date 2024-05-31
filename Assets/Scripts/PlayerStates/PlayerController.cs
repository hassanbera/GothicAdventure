using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IPlayer
{


    public bool isGrounded = false;
    public Transform playerLegs;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public IPlayerState currentState;

    public float Attack { get; set; } = 30;
    public int JumpForce { get; set; } = 8;
    public float Speed { get; set; } = 10;

    public Vector3 lastCheckpoint;


    
    // Start is called before the first frame update
    void Start()
    {
        TransitionToState(new IdleState());
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastCheckpoint = new GameObject().transform.position;
    }
    void Update()
    {
        currentState.UpdateState(this);
        isGrounded = Physics2D.OverlapCircle(playerLegs.position, groundCheckRadius, groundLayer);

        animator.SetBool("isGrounded", !isGrounded);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    public void TransitionToState(IPlayerState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = newState;
        newState.EnterState(this);
    }

    public void SetAnimation(string animationName)
    {
        if (animationName == "Idle")
        {
            animator.SetFloat("speed", 0);
        }

        else if (animationName == "IdleAfterJump")
        {
            animator.SetFloat("speed", 0);
            animator.SetBool("isGrounded", false);
        }

        else if (animationName == "Run")
        {
            animator.SetFloat("speed", 1);
        }

        else if (animationName == "Jump")
        {
            animator.SetBool("isGrounded", true);
        }

        else if (animationName == "notJumping")
        {
            animator.SetBool("isGrounded", !isGrounded);
        }


    }

    public void addXP(int xp)
    {
        FindObjectOfType<PlayerExperience>().ChangeExperience(xp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Apple")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerHealth>().changeHealth(10);
        }

        

    }

    // if a collision is detected
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Knight")
        {
            if (collision.gameObject.GetComponent<KnightEnemy>().IsAttacking == true)
            {
                Debug.Log("Knight is attacking!");
                FindObjectOfType<PlayerHealth>().changeHealth(-collision.gameObject.GetComponent<KnightEnemy>().Damage);
                

                    collision.gameObject.GetComponent<KnightEnemy>().TakeDamage(Attack);

                
            }
        }

        if(collision.gameObject.tag == "King")
        {
            Debug.Log("King is attacking!");
            if (collision.gameObject.GetComponent<KingEnemy>().IsAttacking == true)
            {
                
                FindObjectOfType<PlayerHealth>().changeHealth(-collision.gameObject.GetComponent<KingEnemy>().Damage);
                
                
                collision.gameObject.GetComponent<KingEnemy>().TakeDamage(Attack);
                
            }
        }

        if(collision.gameObject.tag == "Samurai")
        {
            if (collision.gameObject.GetComponent<SamuraiEnemy>().IsAttacking == true)
            {
                Debug.Log("Samurai is attacking!");
                FindObjectOfType<PlayerHealth>().changeHealth(-collision.gameObject.GetComponent<SamuraiEnemy>().Damage);
                
                collision.gameObject.GetComponent<SamuraiEnemy>().TakeDamage(Attack);
                
            }
        }
        

        // if he falls
        if (collision.gameObject.tag == "FallDetector")
        {
            GameManager.instance.RespawnPlayer(this);
        }
    }

    public void ApplyBoost() { }

    
}
