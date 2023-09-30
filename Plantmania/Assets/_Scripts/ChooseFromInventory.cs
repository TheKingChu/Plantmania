using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using UnityEngine.UI;

public class ChooseFromInventory : MonoBehaviour
{
    private Inventory inventory;

    public void Update()
    {
        //dropping item
        foreach (Transform child in transform)
        {
            if (Input.GetMouseButton(1))
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        //using item
    }
}
