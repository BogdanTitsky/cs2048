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

        int number = b.Number * 2;
        int index = GetIndex(number);
        b.SetState(b.State, number, index);
        _score.IncreaseScore();
    }

    private int GetIndex(int number)
    {
        int index = 0;

        for (int i = 0; number != 2; i++)
        {
            index++;
            number /= 2;
        }
        return index;
    }
}
