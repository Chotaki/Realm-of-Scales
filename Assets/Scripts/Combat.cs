using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Combat : MonoBehaviour
{
    public Transform attackPoint;

    public float normalAttackRange = 0.5f;
    public int normalAttackDamage = 20;
    public int chargedAttackDamage = 30;

    [SerializeField] public GameObject fireBall;
    public int spellDamage = 40;
    public bool fireGoLeft = false;

    private float _attackRate = 2f;
    private float _nextAttackTime = 0f;
    private float _attackTimer;
    private float _chargingTime = 2f;

    public int mana = 100;
    public int hp = 10;

    public LayerMask enemyLayer;

    void Update()
    {
        if(Time.time >= _nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log(_attackTimer);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (Time.time - _attackTimer > _chargingTime)
                {
                    Debug.Log(_attackTimer);
                    chargedAttack();
                    _nextAttackTime = Time.time + 1f / _attackRate;
                }
                else
                {
                    normalAttack();
                    _nextAttackTime = Time.time + 1f / _attackRate;
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && mana > 0)
            {
                throwFireBall();
                _nextAttackTime = Time.time + 1f / _attackRate;
            }
        }

        if (this.GetComponent<Movement>().facingRight == false)
        {
            fireBall.GetComponent<Magic>().fireLeft = true;
        }
        else if (this.GetComponent<Movement>().facingRight == true)
        {
            fireBall.GetComponent<Magic>().fireLeft = false;
        }
    }

    public void normalAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, normalAttackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(normalAttackDamage);
        }
    }

    public void chargedAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, normalAttackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(chargedAttackDamage);
        }
    }

    public void throwFireBall()
    {
        Instantiate(fireBall, attackPoint.position, Quaternion.identity);
        mana -= 10;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, normalAttackRange);
    }
}
