using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public string inventoryName;
    public List<Slot_UI> slots = new List<Slot_UI>();
   
    [SerializeField] private Canvas canvas;

    private Inventory inventory;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    private void Start()
    {
        inventory = GameManager.Instance.playerManager.inventoryManager.GetInventoryByName(inventoryName);

        SetupSlots();
        Refresh();
    }

    public void Refresh()
    {
        //refreshing the inventory
        if(slots.Count == inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if (inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove()
    {
        Item itemToDrop = GameManager.Instance.itemManager.GetItemByName(inventory.slots[UIManager.draggedSlot.slotID].itemName);

        if(itemToDrop != null)
        {
            if(UIManager.dragSingle)
            {
                GameManager.Instance.playerManager.DropItem(itemToDrop);
                inventory.Remove(UIManager.draggedSlot.slotID);
            }
            else
            {
                GameManager.Instance.playerManager.DropItem(itemToDrop, inventory.slots[UIManager.draggedSlot.slotID].count);
                inventory.Remove(UIManager.draggedSlot.slotID, inventory.slots[UIManager.draggedSlot.slotID].count);
            }
            Refresh();
        }

        UIManager.draggedSlot = null;
    }

    public void SlotBeginDrag(Slot_UI slot)
    {
        UIManager.draggedSlot = slot;
        UIManager.draggedIcon = Instantiate(UIManager.draggedSlot.itemIcon);
        UIManager.draggedIcon.transform.SetParent(canvas.transform);
        UIManager.draggedIcon.raycastTarget = false;

        UIManager.draggedIcon.rectTransform.sizeDelta = new Vector2(50, 50);

        MoveToMouse(UIManager.draggedIcon.gameObject);
    }

    public void SlotDrag()
    {
        MoveToMouse(UIManager.draggedIcon.gameObject);
    }

    public void SlotEndDrag()
    {
        Destroy(UIManager.draggedIcon.gameObject);
        UIManager.draggedIcon = null;
    }

    public void SlotDrop(Slot_UI slot)
    {
        if (UIManager.dragSingle)
        {
            UIManager.draggedSlot.inventory.MoveSlot(UIManager.draggedSlot.slotID, slot.slotID, slot.inventory);
        }
        else
        {
            UIManager.draggedSlot.inventory.MoveSlot(UIManager.draggedSlot.slotID, slot.slotID, slot.inventory, UIManager.draggedSlot.inventory.slots[UIManager.draggedSlot.slotID].count);
        }
        GameManager.Instance.uiManager.RefreshAll();
    }

    private void MoveToMouse(GameObject toMove)
    {
        if(canvas != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            toMove.transform.position = canvas.transform.TransformPoint(position);
        }
    }

    private void SetupSlots()
    {
        int counter = 0;

        foreach(Slot_UI slot in slots)
        {
            slot.slotID = counter;
            counter++;

            slot.inventory = inventory;
        }
    }
}
