using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] public float _throwSpeed;
 
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.forward * _throwSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Damage Enemies

        Destroy(this.gameObject);
    }
}
