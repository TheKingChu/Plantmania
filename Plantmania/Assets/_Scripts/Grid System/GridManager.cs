using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap interactiveTile = null;
    [SerializeField] private Tilemap pathTile = null;
    [SerializeField] private TileBase hoverTile = null;

    private Vector3Int previousMousePosition = new Vector3Int();

    private void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        Vector3Int mousePosition = GetMousePosition();

        if(!mousePosition.Equals(previousMousePosition))
        {
            interactiveTile.SetTile(previousMousePosition, null);
            interactiveTile.SetTile(mousePosition, hoverTile);
            previousMousePosition = mousePosition;
        }
    }

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPosition);
    }
}
