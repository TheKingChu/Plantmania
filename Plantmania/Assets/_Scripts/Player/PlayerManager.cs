using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(21); //creates a X slot inventory
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

        droppedItem.rb2d.AddForce(spawnOffset * 0.2f, ForceMode2D.Impulse);
    }
}
