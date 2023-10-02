using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(6); //creates a 6 slot inventory
    }
}
