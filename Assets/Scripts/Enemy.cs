using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHp;
    public GameObject enemy;
    public bool isAttacked;

    private void playerAttack()
    {
        enemyHp -= 10;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isAttacked = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                playerAttack();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isAttacked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isAttacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHp == 0)
        {
            enemy.SetActive(false);
        }
    }
}
