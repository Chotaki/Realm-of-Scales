using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magic : MonoBehaviour
{
    private Rigidbody2D _rb;
    public GameObject player;
    [SerializeField] public float _throwSpeed;
 
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Debug.Log(player.GetComponent<Movement>().facingRight == true);

        if (player.GetComponent<Movement>().facingRight)
        {
            Debug.Log("fire to the right");
            _rb.velocity = new Vector2(_throwSpeed, _rb.velocity.y);
        }
        else if (player.GetComponent<Movement>().facingRight == false)
        {
            Debug.Log("fire to the left");
            _rb.velocity = new Vector2(_throwSpeed, Vector3.left.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<Enemy>().takeDamage(player.GetComponent<Combat>().spellDamage);
        }

        Destroy(this.gameObject);
    }
}
