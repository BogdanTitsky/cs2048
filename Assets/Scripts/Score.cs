using UnityEngine;
using Zenject;
using TMPro;

public class Score : MonoBehaviour
{
    [Inject] private TextMeshProUGUI _scoreText;
    private int _scoreValue = 0;
    public void IncreaseScore()
    {
        _scoreValue++;
        _scoreText.text = _scoreValue.ToString();
    }
    public void ResetScore()
    {
        _scoreValue = 0;
        _scoreText.text = _scoreValue.ToString();
    }
}
