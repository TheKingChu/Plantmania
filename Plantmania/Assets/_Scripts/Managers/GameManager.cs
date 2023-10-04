using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TileManager tileManager;
    public ItemManager itemManager;
    public PlayerManager playerManager;
    public UIManager uiManager;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        //DontDestroyOnLoad(this.gameObject);

        tileManager = GetComponent<TileManager>();
        itemManager = GetComponent<ItemManager>();
        uiManager = GetComponent<UIManager>();

        playerManager = FindObjectOfType<PlayerManager>();
    }
}
