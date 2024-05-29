using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public int enemyHp;
    public GameObject enemy;

    private void normalAttack()
    {
        enemyHp -= 10;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                normalAttack();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

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
