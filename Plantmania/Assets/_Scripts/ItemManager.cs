using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item[] items;

    private Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

    private void Awake()
    {
        foreach (Item item in items) 
        {
            AddItem(item);
        }
    }

    private void AddItem(Item item)
    {
        if (!itemDictionary.ContainsKey(item.itemData.itemName))
        {
            itemDictionary.Add(item.itemData.itemName, item);
        }
    }

    public Item GetItemByName(string key)
    {
        if(itemDictionary.ContainsKey(key)) 
        { 
            return itemDictionary[key]; 
        }

        return null;
    }
}
