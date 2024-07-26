using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*      for (int i = 0; i < player.GetComponent<Inventory>().inventory.Count; i++)
        {*/
            if (Input.GetKeyDown(KeyCode.U) /*&& player.GetComponent<Inventory>().inventory[i] == this*/)
            {
                player.GetComponent<Combat>().hp += 10;
                player.GetComponent<Inventory>().inventory.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
        //}  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Inventory>().inventory.Add(this.gameObject);
        }

        this.gameObject.SetActive(false);
    }
}
