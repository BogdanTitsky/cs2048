using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class Board : MonoBehaviour
{
    public TileState[] TileStates => _tileStates;
    public List<Tile> Tiles { get; set; }
    [Inject] private readonly Tile _tilePrefab;
    [Inject] private readonly Merger _merger;
    [Inject] private readonly TileState[] _tileStates;
    [Inject] private readonly GameController _gameController;
    [Inject] private readonly Grid _grid;

    private void Awake()
    {
        Tiles = new List<Tile>(9);
    }
    private void Start()
    {
        _gameController.StartNewGame();
    }

    public void ClearBoard()
    {
        foreach (Cell _cell in _grid.Cells)
        {
            _cell.Tile = null;
        }
        foreach (Tile tile in Tiles)
        {
            Destroy(tile.gameObject);
        }
        Tiles.Clear();
    }

    public void CreateTile(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            Tile _tile = Instantiate(_tilePrefab, _grid.transform);
            _tile.SetState(_tileStates[0], 2);
            _tile.Spawn(_grid.GetRandomEmptyCell());
            Tiles.Add(_tile);
        }
    }

    public bool CheckForGameOver()
    {
        if (Tiles.Count != _grid.Size)
            return false;

        foreach (Tile _tile in Tiles)
        {
            Vector2Int[] directions = new Vector2Int[] { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

            foreach (Vector2Int direction in directions)
            {
                Cell adjacentCell = _grid.GetAdjacentCell(_tile.Cell, direction);
                if (adjacentCell != null && _merger.CanMerge(_tile, adjacentCell.Tile))
                {
                    return false;
                }
            }
        }
        return true;
    }
}