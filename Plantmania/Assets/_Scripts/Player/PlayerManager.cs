using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public HealthBarUI health;

    private void Awake()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    private void Start()
    {
        health = GetComponentInChildren<HealthBarUI>();
    }

    private void Update()
    {
        //interacting with tiles
        //! maybe this is where to put planting?
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int position = new((int)transform.position.x, (int)transform.position.y, 0);

            if(GameManager.Instance.tileManager.IsInteractable(position))
            {
                Debug.Log("interactable");
            }
        }

        //Attacking
        if(Input.GetKeyDown(KeyCode.E) && inventoryManager.CompareTag("Weapon"))
        {
            Debug.Log("has weapon in hand");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();

        if (enemy)
        {
            LoseHealth();
        }
    }

    public void LoseHealth()
    {
        //check which enemy is attacking
        //get the dmg from enemy and -- that to the currenthealth
        health.currentHealth--;
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 1.5f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        droppedItem.rb2d.AddForce(spawnOffset * 0.02f, ForceMode2D.Impulse);
    }

    public void DropItem(Item item, int numToDrop)
    {
        for (int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }
    }
}
