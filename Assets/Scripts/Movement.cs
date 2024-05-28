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
        // On r�cup�re le rigidBody de notre joueur
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // On r�cup�re l'input qui nous signal si on va � gauche ou � doite
        move = Input.GetAxis("Horizontal");

        // On change la velocit� du rigibBody du joueur pour se d�placer
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
}
