using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;
    [SerializeField] bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.right * speed, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.left * speed, Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            isJumping = false;
        }
    }
}
