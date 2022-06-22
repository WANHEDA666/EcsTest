using Components;
using Leopotam.EcsLite;
using MonoBehaviours;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class PlayerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private PlayerView playerView;
        
        [Inject]
        private void Construct(PlayerView playerView)
        {
            this.playerView = playerView;
        }
        
        public void Init(EcsSystems systems)
        {
            var playerEntity = systems.GetWorld().NewEntity();
            var playersComponentPool = systems.GetWorld().GetPool<PlayerComponent>();
            playersComponentPool.Add(playerEntity);
            ref var playerComponent = ref playersComponentPool.Get(playerEntity);
            playerComponent.PlayerView = playerView;
            playerComponent.Position = new SimpleVector2(playerComponent.PlayerView.Position.x, playerComponent.PlayerView.Position.y);
            var inputComponentPool = systems.GetWorld().GetPool<InputComponent>(); 
            inputComponentPool.Add(playerEntity);
        }

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerComponent>().End();
            var inputComponentPool = world.GetPool<InputComponent>();
            var playerComponentPool = world.GetPool<PlayerComponent>();
            
            foreach (int entity in filter)
            {
                ref var inputComponent = ref inputComponentPool.Get(entity);
                ref var playerComponent = ref playerComponentPool.Get(entity);
                var destination = new Vector3(inputComponent.Position.x, 0, inputComponent.Position.y);
                var moveVector = Vector3.MoveTowards(new Vector3(playerComponent.Position.x, 0, playerComponent.Position.y), 
                    destination, 0.01f);
                playerComponent.Position = new SimpleVector2(moveVector.x, moveVector.z);
                playerComponent.PlayerView.Position = new SimpleVector2(playerComponent.Position.x, playerComponent.Position.y);
                playerComponent.PlayerView.Target = new SimpleVector2(destination.x, destination.z);
            }
        }
    }
}