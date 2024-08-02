using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp = 100;
    private int _currentHp;

    

    void Start()
    {
        _currentHp = maxHp;
    }

    public void takeDamage(int damage)
    {
        _currentHp -= damage;

        if (_currentHp <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Debug.Log("Enemy died");

        this.gameObject.SetActive(false);
    }
}
