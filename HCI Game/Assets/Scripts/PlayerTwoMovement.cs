using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.right * speed, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.left * speed, Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
        {
            Debug.Log("touch ground");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            isJumping = false;
        }
    }
}
