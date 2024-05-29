using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jump;
    private bool isFloored = false;
    private bool doubleJump;
    private float move;
    private Rigidbody2D rb;

    private void Start()
    {
        isFloored = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isFloored = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isFloored = false;
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (isFloored && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isFloored || doubleJump)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jump));
                doubleJump = !doubleJump;
            }
        }

        if (Input.GetButtonDown("Sprint"))
        {
            speed += 10;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            speed -= 10;
        }
    }
}