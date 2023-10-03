using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item[] items;

    private Dictionary<string, Item> nameToItemDictionary = new Dictionary<string, Item>();

    private void Awake()
    {
        foreach (Item item in items) 
        {
            AddItem(item);
        }
    }

    private void AddItem(Item item)
    {
        if (!nameToItemDictionary.ContainsKey(item.data.itemName))
        {
            nameToItemDictionary.Add(item.data.itemName, item);
        }
    }

    public Item GetItemByName(string key)
    {
        if(nameToItemDictionary.ContainsKey(key)) 
        { 
            return nameToItemDictionary[key]; 
        }

        return null;
    }
}
