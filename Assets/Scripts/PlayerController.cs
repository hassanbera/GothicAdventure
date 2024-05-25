using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(playerLegs.position, groundCheckRadius, groundLayer);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        

        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        // when i jump the player keeps flying
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        if(Input.GetKeyDown(KeyCode.Y))
        {
            // just attack one time when it's pressed
            animator.SetTrigger("isAttacking");
            
            // after the attack is done, set the trigger to false
            animator.ResetTrigger("isAttacking");
        }

        

        animator.SetFloat("speed", Mathf.Abs(horizontal));
        animator.SetBool("isGrounded", !isGrounded);
    }
}
