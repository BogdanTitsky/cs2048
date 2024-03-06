using UnityEngine;
using UnityEngine.UI;

public class SelectAvatar : MonoBehaviour
{
    public int Id;
    private Image _newAvatarImage; 
    
    void Start()
    {
        _newAvatarImage = GetComponent<Image>();
    }

    public void OnButtonClick()
    {
        GameObject targetObject = GameObject.Find("SelectedAvatar");
        Image targetImage = targetObject.GetComponent<Image>();
        targetImage.sprite = _newAvatarImage.sprite;
        PlayerPrefs.SetInt("AvatarId", Id);
    }
}