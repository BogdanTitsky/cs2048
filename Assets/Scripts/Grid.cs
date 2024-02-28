using UnityEngine;

public class Grid : MonoBehaviour
{
    public Cell[] Cells { get; private set; }
    public int Size => Cells.Length;
    public int Height => _rows.Length;
    public int Width => Size / Height;
    private Row[] _rows;
    private void Awake()
    {
        _rows = GetComponentsInChildren<Row>();
        Cells = GetComponentsInChildren<Cell>();

        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i].Coordinates = new Vector2Int(i % Width, i / Width);
        }
    }

    public Cell GetCell(Vector2Int coordinates)
    {
        return GetCell(coordinates.x, coordinates.y);
    }

    public Cell GetCell(int x, int y)
    {
        if (x >= 0 && x < Width && y >= 0 && y < Height)
        {
            return _rows[y].Cells[x];
        }
        else
        {
            return null;
        }
    }

    public Cell GetAdjacentCell(Cell cell, Vector2Int direction)
    {
        Vector2Int coordinates = cell.Coordinates;
        coordinates.x += direction.x;
        coordinates.y -= direction.y;

        return GetCell(coordinates);
    }

    public Cell GetRandomEmptyCell()
    {
        int index = Random.Range(0, Cells.Length);
        int startedIndex = index;

        while (Cells[index].Occupied)
        {
            index++;

            if (index >= Cells.Length)
            {
                index = 0;
            }
            if (index == startedIndex)
            {
                return null;
            }
        }

        return Cells[index];
    }
}
