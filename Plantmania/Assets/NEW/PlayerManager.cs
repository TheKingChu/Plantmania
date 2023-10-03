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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);


        }
    }

    public void DropItem()
    {

    }
}
