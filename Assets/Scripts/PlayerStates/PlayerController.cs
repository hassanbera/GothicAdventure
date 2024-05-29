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

    public float Attack { get; set; } = 10;
    public int JumpForce { get; set; } = 10;
    public float Speed { get; set; } = 10;
    // Start is called before the first frame update
    void Start()
    {
        TransitionToState(new IdleState());
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Apple")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerHealth>().changeHealth(10);
        }

        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerExperience>().ChangeExperience(10);
        }
    }

    public void ApplyBoost() { }

    
}
