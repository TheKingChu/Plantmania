using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public CollectableType collectableType;
        public int count;
        public int maxStack;
        public Sprite icon;

        //constructer for slot class
        public Slot()
        {
            collectableType = CollectableType.None;
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

        public void AddItem(Collectable item)
        {
            this.collectableType = item.collectableType;
            this.icon = item.icon;
            count++;
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

    public void Add(Collectable itemToAdd)
    {
        //if there already is a item of that type add to the stack
        foreach (Slot slot in slots)
        {
            if(slot.collectableType == itemToAdd.collectableType && slot.IsCollectable())
            {
                slot.AddItem(itemToAdd);
                return;
            }
        }

        //if there is no item in the slot add to the slot
        foreach (Slot slot in slots)
        {
            if(slot.collectableType == CollectableType.None)
            {
                slot.AddItem(itemToAdd);
                return;
            }
        }
    }
}
