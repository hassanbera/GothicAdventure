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
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        

        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("attack", true);
        }

        if(Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("attack", false);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetBool("attack2", true);
        }

        if (Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("attack2", false);
        }

        animator.SetFloat("speed", Mathf.Abs(horizontal));
        animator.SetBool("isGrounded", !isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Apple")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerHealth>().changeHealth(10);
        }
    }

}
