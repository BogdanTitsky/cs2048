using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public TileState State { get; private set; }
    public Cell Cell { get; private set; }
    public int Number { get; private set; }
    public bool Locked;
    private Image _background;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _background = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetState(TileState state, int number)
    {
        State = state;
        Number = number;

        _background.color = state.BackgroundColor;
        _text.color = state.TextColor;
        _text.text = number.ToString();
    }

    public void Spawn(Cell cell)
    {
        if (Cell != null)
        {
            Cell.Tile = null;
        }

        Cell = cell;
        Cell.Tile = this;

        transform.position = cell.transform.position;
    }

    public void MoveTo(Cell cell)
    {
        if (Cell != null)
        {
            Cell.Tile = null;
        }

        Cell = cell;
        Cell.Tile = this;

        StartCoroutine(Animate(cell.transform.position, false));
    }

    public void Merge(Cell cell)
    {
        if (Cell != null)
        {
            Cell.Tile = null;
        }

        Cell = null;
        cell.Tile.Locked = true;

        StartCoroutine(Animate(cell.transform.position, true));
    }

    private IEnumerator Animate(Vector3 to, bool merging)
    {
        float elapsed = 0f;
        float duration = 0.2f;

        Vector3 from = transform.position;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = to;

        if (merging)
        {
            Destroy(gameObject);
        }
    }
}
