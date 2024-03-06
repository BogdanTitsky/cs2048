using System;
using System.Collections;
using System.Collections.Generic;
using ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject avatarFrame;

    EcsWorld _world;
    EcsSystems _systems;
    void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems.Add(new AvatarInitSystem(avatarFrame));
        _systems.Add(new ChangeCurrentAvatarSystem());
        
        _systems.Init();
    }

    private void Update()
    {
        _systems.Run();
    }
    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}
