using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    None,
    NormalSeed,
    TankSeed,
    Weapon
}

public class Collectable : MonoBehaviour
{
    PlayerManager player;

    public CollectableType collectableType;
    public Sprite icon;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }
}
