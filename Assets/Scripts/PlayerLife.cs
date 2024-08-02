using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    [SerializeField] private AudioClip playerHurt;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(int damage)
    {
        SFXManager.instance.PlaySFXClip(playerHurt, transform, 1f);
        currentHealth -= damage;
    }

}
