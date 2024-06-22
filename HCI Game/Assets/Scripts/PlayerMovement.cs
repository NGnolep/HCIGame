using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
    }
}
