using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magic : MonoBehaviour
{
    private Rigidbody2D _rb;
    public GameObject player;
    public bool fireLeft = false;
    [SerializeField] public float throwSpeed;
 
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Vector2 force = new Vector2(Vector3.right.x, Vector3.right.y);
        if (fireLeft == true)
        {
            //Debug.Log("fire to the left");
            //_rb.velocity = new Vector2(throwSpeed, Vector3.left.x);
            _rb.AddForce(transform.right * -1, ForceMode2D.Impulse);
        }
        else
        {
            //Debug.Log("fire to the right");
            //_rb.velocity = new Vector2(throwSpeed, Vector3.right.x);
            _rb.AddForce(transform.right, ForceMode2D.Impulse);
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
