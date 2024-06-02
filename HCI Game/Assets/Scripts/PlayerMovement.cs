using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedjump;
    private Rigidbody2D body;
    private bool isJumping;
    private Animator anim;
    private SpriteRenderer spriteRen;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        if(body.velocity.magnitude > 0)
        {
            anim.Play("playerMovement");
        }
        else
        {
            anim.Play("idle");
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRen.flipX = true;
        }
        else
        {
            spriteRen.flipX = false;
        }

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            body.velocity = new Vector2(body.velocity.x, speedjump);
            isJumping = true; 
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
