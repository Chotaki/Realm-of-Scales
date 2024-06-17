using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Transform attackPoint;

    public float normalAttackRange = 0.5f;
    public int normalAttackDamage = 20;

    public int mana = 100;

    [SerializeField] public GameObject fireBall;
    [SerializeField] public Transform origin;
    public int spellDamage = 40;

    private float _attackRate = 2f;
    private float _nextAttackTime = 0f;

    public LayerMask enemyLayer;

    void Update()
    {
        if(Time.time >= _nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                normalAttack();
                _nextAttackTime = Time.time + 1f / _attackRate;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                throwFireBall();
                _nextAttackTime = Time.time + 1f / _attackRate;
            }
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

    public void throwFireBall()
    {
        Instantiate(fireBall, origin.position, origin.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, normalAttackRange);
    }
}
