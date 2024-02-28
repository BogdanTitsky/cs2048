using UnityEngine;
using System.Collections;
using Zenject;

public class Mover : MonoBehaviour
{
    private bool _waiting;
    [Inject] private readonly Merger _merger;
    [Inject] private readonly Board _board;
    [Inject] private readonly Grid _grid;
    [Inject] private readonly GameController _gameController;

    private Vector2 _lastMousePosition;
    private void Update()
    {
        if (!_waiting)
        {
            HandleSwipe();
        }
    }

    public void HandleSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 swipeDirection = (Vector2)Input.mousePosition - _lastMousePosition;
            if (swipeDirection.magnitude > 50f)
            {
                if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                {
                    if (swipeDirection.x > 0)
                    {
                        MoveAll(Vector2Int.right, _grid.Width - 1, -1, 0, 1);
                    }
                    else
                    {
                        MoveAll(Vector2Int.left, 1, 1, 0, 1);
                    }
                }
                else
                {
                    if (swipeDirection.y > 0)
                    {
                        MoveAll(Vector2Int.up, 0, 1, 1, 1);
                    }
                    else
                    {
                        MoveAll(Vector2Int.down, 0, 1, _grid.Height - 1, -1);
                    }
                }
            }
        }
    }

    private void MoveAll(Vector2Int direction, int startX, int incrementX, int startY, int incrementY)
    {
        bool changed = false;
        for (int x = startX; x >= 0 && x < _grid.Width; x += incrementX)
        {
            for (int y = startY; y >= 0 && y < _grid.Height; y += incrementY)
            {
                Cell cell = _grid.GetCell(x, y);

                if (cell.Occupied)
                {
                    changed |= MoveTile(cell.Tile, direction);
                }
            }
        }
        if (changed)
        {
            StartCoroutine(WaitForChanges());
        }
    }

    private bool MoveTile(Tile tile, Vector2Int direction)
    {
        Cell newCell = null;
        Cell adjacentCell = _grid.GetAdjacentCell(tile.Cell, direction);

        while (adjacentCell != null)
        {
            if (adjacentCell.Occupied)
            {
                if (_merger.CanMerge(tile, adjacentCell.Tile))
                {
                    _merger.MergeTiles(tile, adjacentCell.Tile);
                    return true;
                }

                break;
            }

            newCell = adjacentCell;
            adjacentCell = _grid.GetAdjacentCell(adjacentCell, direction);
        }

        if (newCell != null)
        {
            tile.MoveTo(newCell);
            return true;
        }

        return false;
    }

    public IEnumerator WaitForChanges()
    {
        _waiting = true;

        yield return new WaitForSeconds(0.2f);

        _waiting = false;

        foreach (var Tile in _board.Tiles)
        {
            Tile.Locked = false;
        }

        int numberOfTilesToCreate = Random.Range(2, 4);

        for (int i = 0; i < numberOfTilesToCreate; i++)
        {
            if (_board.Tiles.Count != _grid.Size)
            {
                _board.CreateTile();
            }
        }
        if (_board.CheckForGameOver())
        {
            _gameController.GameOver();
        }
    }

}
