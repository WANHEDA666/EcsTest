using Components;
using Leopotam.EcsLite;
using UnityEngine;
using Utils;

namespace Systems
{
    public class PlayerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private GameData gameData;
        
        public void Init(EcsSystems systems)
        {
            gameData = systems.GetShared<GameData>();
            var playerEntity = systems.GetWorld().NewEntity();
            
            var playersPool = systems.GetWorld().GetPool<PlayerComponent>();
            playersPool.Add(playerEntity);
            var moveComponentPool = systems.GetWorld().GetPool<MoveComponent>(); 
            moveComponentPool.Add(playerEntity);
            var inputComponentPool = systems.GetWorld().GetPool<InputComponent>(); 
            inputComponentPool.Add(playerEntity);
        }

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerComponent>().End();
            var playerComponents = world.GetPool<PlayerComponent>();
            var moveComponentPool = world.GetPool<MoveComponent>();
            var inputComponentPool = world.GetPool<InputComponent>();
            
            foreach (int entity in filter)
            {
                ref var playerComponent = ref playerComponents.Get(entity);
                ref var playerMoveComponent = ref moveComponentPool.Get(entity);
                ref var inputComponentComponent = ref inputComponentPool.Get(entity);
                playerMoveComponent.Destination = new Vector3(inputComponentComponent.XDirection, 0, inputComponentComponent.ZDirection);
                playerMoveComponent.Speed = 0.5f;
                playerComponent.Transform = gameData.Transform;
                playerComponent.Transform.LookAt(playerMoveComponent.Destination);
                playerComponent.Transform.position = Vector3.MoveTowards(
                    playerComponent.Transform.position, playerMoveComponent.Destination, playerMoveComponent.Speed * Time.deltaTime);
            }
        }
    }
}