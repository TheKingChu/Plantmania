using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactable;
    [SerializeField] private TileBase hiddenInteractableTile;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var position in interactable.cellBounds.allPositionsWithin)
        {
            interactable.SetTile(position, hiddenInteractableTile);
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactable.GetTile(position);

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
