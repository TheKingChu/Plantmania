using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject interactable;
    [SerializeField] private TileBase hiddenInteractableTile;

    private Tilemap inter;

    private void Awake()
    {
        interactable = GameObject.FindGameObjectWithTag("tileInteractable");
        inter = interactable.GetComponent<Tilemap>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var position in inter.cellBounds.allPositionsWithin)
        {
            TileBase tile = inter.GetTile(position);
            if (tile != null && tile.name == "Interactable_Vision")
            {
                inter.SetTile(position, hiddenInteractableTile);
            }
        }
    }

    private void Update()
    {
        if (interactable != null)
        {
            GameObject.FindGameObjectWithTag("tileInteractable");
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = inter.GetTile(position);

        if(tile != null)
        {
            if(tile.name == "Interactable")
            {
                return true;
            }
        }

        return false;
    }
}
