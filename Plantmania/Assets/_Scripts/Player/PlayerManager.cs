using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int position = new((int)transform.position.x, (int)transform.position.y, 0);

            if(GameManager.Instance.tileManager.IsInteractable(position))
            {
                Debug.Log("interactable");
            }
        }
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
