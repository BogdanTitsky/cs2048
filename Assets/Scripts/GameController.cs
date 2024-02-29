using UnityEngine;
using Zenject;
public class GameController : MonoBehaviour
{
    [Inject] private Board _board;
    [Inject] private PopUpGameOver _gameOverPopUp;

    public void StartNewGame()
    {
        _gameOverPopUp.HidePopUp();
        _board.ResetBoard();
    }
    public void GameOver()
    {
        _gameOverPopUp.ShowPopUp();
        _board.enabled = false;
    }
}
