using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public string itemName;
        public int count;
        public int maxStack;
        public Sprite icon;

        //constructer for slot class
        public Slot()
        {
            itemName = "";
            count = 0;
            maxStack = 99; //can be changed
        }

        public bool IsCollectable()
        {
            if(count < maxStack)
            {
                return true;
            }

            //else return false
            return false;
        }

        public void AddItem(Item item)
        {
            this.itemName = item.itemData.itemName;
            this.icon = item.itemData.icon;
            count++;
        }

        public void RemoveItem()
        {
            if(count > 0)
            {
                count--;

                if(count == 0)
                {
                    icon = null;
                    itemName = "";
                }
            }
        }
    }

    public List<Slot> slots = new List<Slot>();

    //constructer for inventory, this will set up the slot list
    public Inventory(int numSlots) 
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Item itemToAdd)
    {
        //if there already is a item of that type add to the stack
        foreach (Slot slot in slots)
        {
            if(slot.itemName == itemToAdd.itemData.itemName && slot.IsCollectable())
            {
                slot.AddItem(itemToAdd);
                return;
            }
        }

        //if there is no item in the slot add to the slot
        foreach (Slot slot in slots)
        {
            if(slot.itemName == "")
            {
                slot.AddItem(itemToAdd);
                return;
            }
        }
    }

    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }
}
