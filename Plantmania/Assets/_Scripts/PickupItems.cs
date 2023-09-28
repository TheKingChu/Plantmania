using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //checks for player to be colliding with item for this to run
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false) //if its false then item can be added to inventory
                {

                    //when its full it will stop the loop
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false); //spawns in the button on the inventory UI slot
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
