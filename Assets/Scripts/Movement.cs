using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jump;
    private bool _isFloored = false;
    private bool _doubleJump;
    private float _move;
    private Rigidbody2D _rb;

    private void Start()
    {
        _isFloored = false;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isFloored = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isFloored = false;
    }

    void Update()
    {
        _move = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(_move * speed, _rb.velocity.y);

        if (_isFloored && !Input.GetButton("Jump"))
        {
            _doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (_isFloored || _doubleJump)
            {
                _rb.AddForce(new Vector2(_rb.velocity.x, jump));
                _doubleJump = !_doubleJump;
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