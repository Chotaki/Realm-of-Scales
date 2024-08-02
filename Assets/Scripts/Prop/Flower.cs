using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public GameObject player;
    [SerializeField] private AudioClip manaPickup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SFXManager.instance.PlaySFXClip(manaPickup, transform, 1f); 
            player.GetComponent<Combat>().mana += 10;
            this.gameObject.SetActive(false);
        }
    }
}
