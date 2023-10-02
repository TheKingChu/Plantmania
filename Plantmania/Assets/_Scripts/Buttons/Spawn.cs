using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    

    public void SpawnDroppedItem()
    {
        Vector2 playerPosition = new Vector2(playerTransform.position.x, playerTransform.position.y + 2);
        Instantiate(item, playerPosition, Quaternion.identity);
    }
}
