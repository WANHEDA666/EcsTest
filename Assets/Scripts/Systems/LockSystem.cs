using Components;
using Leopotam.EcsLite;
using MonoBehaviours;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class LockSystem : IEcsInitSystem, IEcsRunSystem
    {
        private LockView[] locksView;
        
        [Inject]
        private void Construct(LockView[] locksView)
        {
            this.locksView = locksView;
        }
        
        public void Init(EcsSystems systems)
        {
            foreach (var lockView in locksView)
            {
                var lockEntity = systems.GetWorld().NewEntity();
                var locksComponentPool = systems.GetWorld().GetPool<LockComponent>();
                locksComponentPool.Add(lockEntity);
                ref var lockComponent = ref locksComponentPool.Get(lockEntity);
                lockComponent.LockView = lockView;
                lockComponent.ButtonPosition = new SimpleVector2(lockView.Button.position.x, lockView.Button.position.z);
                lockComponent.DoorPosition = new SimpleVector2( lockView.DoorView.Door.localPosition.x,  lockView.DoorView.Door.localPosition.z);
            }
        }

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<LockComponent>().End();
            var filterPlayer = world.Filter<PlayerComponent>().End();
            var playerComponents = world.GetPool<PlayerComponent>();
            var lockComponents = world.GetPool<LockComponent>();
            foreach (int entity in filter)
            {
                var playerComponent = new PlayerComponent();
                foreach (int entityPlayer in filterPlayer)
                {
                    playerComponent = playerComponents.Get(entityPlayer);
                }
                ref var lockComponent = ref lockComponents.Get(entity);
                if (Vector3.Distance(new Vector3(playerComponent.Position.x, 0, playerComponent.Position.y), 
                    new Vector3(lockComponent.ButtonPosition.x, 0, lockComponent.ButtonPosition.y)) <= 0.3f)
                {
                    var destination = Vector3.MoveTowards(new Vector3(lockComponent.DoorPosition.x, 0, lockComponent.DoorPosition.y), 
                        new Vector3(), 0.5f * Time.deltaTime);
                    lockComponent.DoorPosition = new SimpleVector2(destination.x, destination.z);
                }
            }
        }
    }
}