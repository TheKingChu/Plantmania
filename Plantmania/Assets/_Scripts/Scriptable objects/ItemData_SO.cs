using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Item Data", order = 50)]
public class ItemData_SO : ScriptableObject
{
    public string itemName = "Item Name";
    public Sprite icon;
}
