using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public PlayerManager player;
    public List<Slot_UI> slots = new List<Slot_UI>();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if(!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    private void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotID)
    {
        Item itemToDrop = GameManager.Instance.itemManager.GetItemByName(player.inventory.slots[slotID].itemName);

        if(itemToDrop != null)
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(slotID);
            Refresh();
        }
    }
}
