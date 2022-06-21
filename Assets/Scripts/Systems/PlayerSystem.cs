using Components;
using Interfaces;
using Leopotam.EcsLite;

namespace Systems
{
    public class PlayerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private GameData gameData;
        private IPlayerView playerView;
        
        public void Init(EcsSystems systems)
        {
            gameData = systems.GetShared<GameData>();
            var playerEntity = systems.GetWorld().NewEntity();
            
            var playersComponentPool = systems.GetWorld().GetPool<PlayerComponent>();
            playersComponentPool.Add(playerEntity);
            var moveComponentPool = systems.GetWorld().GetPool<MoveComponent>(); 
            moveComponentPool.Add(playerEntity);
            var inputComponentPool = systems.GetWorld().GetPool<InputComponent>(); 
            inputComponentPool.Add(playerEntity);

            playerView = gameData.PlayerView;
        }

        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerComponent>().End();
            var inputComponentPool = world.GetPool<InputComponent>();
            var playerComponentPool = world.GetPool<PlayerComponent>();
            
            foreach (int entity in filter)
            {
                ref var inputComponentComponent = ref inputComponentPool.Get(entity);
                ref var playerComponent = ref playerComponentPool.Get(entity);
                playerView.Move(ref playerComponent, inputComponentComponent);
            }
        }
    }
}