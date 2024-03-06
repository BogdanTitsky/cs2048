using UnityEngine;
using UnityEngine.UI;

public class GameAvatar : MonoBehaviour
{
     private int avatarId;
    [SerializeField] private AvatarInitData avatarInitData;
    [SerializeField] private Image image;
    
    private void Start()
    {
        avatarId = PlayerPrefs.GetInt("AvatarId");
        GetAvatarById(avatarId);
    }

    private void GetAvatarById(int id)
    {
        var avatarById = avatarInitData.GetAvatarById(id);
        image.sprite = avatarById.Sprite;
    }
}

