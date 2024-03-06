using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AvatarInitData : ScriptableObject
{
    [SerializeField] private Avatar[] avatars;
    public Dictionary<int, Avatar> _avatarsDictionary;
    public GameObject prefab;

    public Avatar[] Avatars => avatars;
        
    private void OnEnable()
    {
        _avatarsDictionary = new Dictionary<int, Avatar>();

        foreach (var avatar in avatars)
            _avatarsDictionary.Add(avatar.Id, avatar);
    }

    public Avatar GetAvatarById(int id)
    {
        try
        {
            return _avatarsDictionary[id];
        }
        catch (Exception e)
        {
            throw new Exception(
                $"[{nameof(AvatarInitData)}] AvatarVo by type {id.ToString()} was not present in the dictionary. {e.StackTrace}");
        }
    }

    public static AvatarInitData LoadFromAssets()
    {
        return Resources.Load<AvatarInitData>("Data/AvatarInitData");
    }
}