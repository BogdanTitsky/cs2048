using UnityEngine;

public class PopUpGameOver : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void ShowPopUp()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
    }

    public void HidePopUp()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }
}
