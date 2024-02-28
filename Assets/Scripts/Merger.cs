using UnityEngine;
using Zenject;

public class Merger : MonoBehaviour
{
    [Inject] private Board _board;
    [Inject] private Score _score;

    public bool CanMerge(Tile a, Tile b)
    {
        return a.Number == b.Number && !b.Locked;
    }

    public void MergeTiles(Tile a, Tile b)
    {
        _board.Tiles.Remove(a);
        a.Merge(b.Cell);

        int index = Mathf.Clamp(IndexOf(b.State) + 1, 0, _board.TileStates.Length - 1);
        int number = b.Number * 2;
        b.SetState(_board.TileStates[index], number);
        _score.IncreaseScore();
    }

    private int IndexOf(TileState state)
    {
        for (int i = 0; i < _board.TileStates.Length; i++)
        {
            if (state == _board.TileStates[i])
            {
                return i;
            }
        }

        return -1;
    }
}
