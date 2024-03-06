using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class ChangeCurrentAvatarSystem : IEcsRunSystem
    {
        private EcsFilter<isCurrentAvatar, AvatarId> _currentAvatarFilter = null;
        private readonly EcsFilter<AvatarId> _allAvatarsFilter = null;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var currentAvatarEntity = _currentAvatarFilter.GetEntity(0);

                currentAvatarEntity.Del<isCurrentAvatar>();

                var newAvatarId = _allAvatarsFilter.GetEntity(0).Get<AvatarId>().id;

                var newAvatarEntity = _allAvatarsFilter.GetEntity(newAvatarId);
                newAvatarEntity.Get<isCurrentAvatar>();
            }
        }
    }
}