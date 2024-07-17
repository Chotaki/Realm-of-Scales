using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public BoxCollider2D feet;
    public bool facingRight = true;

    public Vector3 moveDirection;

    private bool _canDash = true;
    private bool _isDashing;
    private float _dashingPower = 24f;
    private float _dashingTime = 0.2f;
    private float _dashingCooldown = 1f;

    public SpriteRenderer spriteRenderer;
    public Sprite crouching;
    public Sprite standing;
    public BoxCollider2D boxCollider;
    public Vector2 standingSize;
    public Vector2 crouchingSize;

    public Animator animator;

    [SerializeField] private TrailRenderer _trailRenderer;

    private void Start()
    {
        _canDash = true;
        _isFloored = false;
        facingRight = true;
        _rb = GetComponent<Rigidbody2D>();

        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = standing;
        standingSize = boxCollider.size;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(boxCollider.name);
        //Debug.Log(collision.gameObject.tag);

        if (feet == collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("is_Floored");
            _isFloored = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isFloored = false;
        //Debug.Log("coll exit");
    }

    void Update()
    {
        if (_isDashing)
        {
            return;
        }

        // Walk
        _move = Input.GetAxis("Horizontal"); // Q & D

        _rb.velocity = new Vector2(_move * speed, _rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(_move));

        // Flip the player, when walking
        if (_move > 0 && !facingRight)
        {
            Flip();
            facingRight = true;
        }
        else if (_move < 0 && facingRight)
        {
            Debug.Log("go left");
            facingRight = false;
            Flip();
            Debug.Log(facingRight);
        }

        // Jump
        if (_isFloored && !Input.GetButton("Jump")) // Space
        {
            _doubleJump = false;
        }

        // Double Jump
        if (Input.GetButtonDown("Jump")) // Space
        {
            if (_isFloored || _doubleJump)
            {
                _rb.AddForce(new Vector2(_rb.velocity.x, jump));
                _doubleJump = !_doubleJump;
            }
        }

        // Sprint
        if (Input.GetButtonDown("Sprint")) // Right Mouse Button
        {
            speed += 10;
            animator.SetFloat("Speed", 10.1f);
        }
        if (Input.GetButtonUp("Sprint")) // Right Mouse Button
        {
            speed -= 10;
            animator.SetFloat("Speed", Mathf.Abs(_move));
        }

        // Dash
        if (Input.GetButtonDown("Dash")) // R
        {
            animator.SetBool("IsDashing", true);
            StartCoroutine(Dash());
        }

        // Crouch
        if (Input.GetButtonDown("Crouch")) // C
        {
            spriteRenderer.sprite = crouching;
            boxCollider.size = crouchingSize;   
        }
        if (Input.GetButtonUp("Crouch")) // C
        {
            spriteRenderer.sprite = standing;
            boxCollider.size = standingSize;
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }

    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(_move * _dashingPower, 0f);
        _trailRenderer.emitting = true;
        yield return new WaitForSeconds(_dashingTime);
        _trailRenderer.emitting = false;
        _rb.gravityScale = originalGravity;
        _isDashing = false;
        animator.SetBool("IsDashing", false);
        yield return new WaitForSeconds(_dashingCooldown);
        _canDash = true;
    }
}