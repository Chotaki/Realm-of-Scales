using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private float move;
    private Rigidbody2D rb;

    private void Start()
    {
        // On récupère le rigidBody de notre joueur
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // On rècupère l'input qui nous signal si on va à gauche ou à doite
        move = Input.GetAxis("Horizontal");

        // On change la velocité du rigibBody du joueur pour se déplacer
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
}
