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

        public void AddItem(CollectableType collectableType)
        {
            this.collectableType = collectableType;
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

    public void Add(CollectableType typeToAdd)
    {
        //if there already is a item of that type add to the stack
        foreach (Slot slot in slots)
        {
            if(slot.collectableType == typeToAdd && slot.IsCollectable())
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }

        //if there is no item in the slot add to the slot
        foreach (Slot slot in slots)
        {
            if(slot.collectableType == CollectableType.None)
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }
    }
}
