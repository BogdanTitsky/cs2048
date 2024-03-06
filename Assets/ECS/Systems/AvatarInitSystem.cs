using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI; 


public class AvatarInitSystem : IEcsInitSystem
{
    EcsWorld _world = null;
    private GameObject _avatarFrame;
    public AvatarInitSystem(GameObject avatarFrame)
    {
        _avatarFrame = avatarFrame;
    }
    
    public void Init()
    {
        
        for (int i = 0; i < 6; i++)
        {
            CreateAvatar(i);
        }
    }

    private void CreateAvatar(int index)
    {
        var avatarEntity = _world.NewEntity();
        avatarEntity.Get<AvatarId>().id = index;
        //Default current avatar
        if (index == 0)
        {
            avatarEntity.Get<isCurrentAvatar>();
        }

        var spawnedAvatarPrefab = GameObject.Instantiate(AvatarInitData.LoadFromAssets().prefab, Vector3.zero ,Quaternion.identity);

        spawnedAvatarPrefab.transform.SetParent(_avatarFrame.transform);
        
        SelectAvatar selectAvatar = spawnedAvatarPrefab.GetComponent<SelectAvatar>();
        
        selectAvatar.Id = index;
        
        var imageComponent = spawnedAvatarPrefab.GetComponent<Image>();
        if (imageComponent != null)
        {
            var avatarById =  AvatarInitData.LoadFromAssets().GetAvatarById(index);
            imageComponent.sprite = avatarById.Sprite;
        }
    }
}


