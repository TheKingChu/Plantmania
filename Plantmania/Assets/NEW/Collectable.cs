using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    None,
    NormalSeed,
    TankSeed
}

public class Collectable : MonoBehaviour
{
    public CollectableType collectableType;
    PlayerManager player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player)
        {
            player.inventory.Add(collectableType);
            Destroy(this.gameObject);
        }
    }
}
