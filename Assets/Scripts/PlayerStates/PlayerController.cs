using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IPlayer
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public bool isGrounded = false;
    public Transform playerLegs;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public IPlayerState currentState;

    public virtual int JumpForce
    {
        get => JumpForce;
        set => JumpForce = value;
    }
    public virtual float Speed
    {
        get => Speed;
        set => Speed = value;
    }
    public virtual float Attack
    {
        get => Attack;
        set => Attack = value;
    }
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
    }

    public void ApplyBoost() { }
}
