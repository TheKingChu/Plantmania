using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory_UI : MonoBehaviour
{
    public PlayerManager player;
    public List<Slot_UI> slots = new List<Slot_UI>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetupInventoryUI()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].collectableType != CollectableType.None)
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
}
