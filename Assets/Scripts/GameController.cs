using UnityEngine;
using Zenject;
public class GameController : MonoBehaviour
{
    [Inject] private Board _board;
    [Inject] private Score _score;
    [Inject] private CanvasGroup _gameOverPopUp;
    public void StartNewGame()
    {
        _score.ResetScore();
        _gameOverPopUp.alpha = 0;
        _gameOverPopUp.interactable = false;
        _board.ClearBoard();
        _board.CreateTile(2);
        _board.enabled = true;
    }
    public void GameOver()
    {
        _gameOverPopUp.alpha = 1;
        _gameOverPopUp.interactable = true;
        _board.enabled = false;
    }
}
