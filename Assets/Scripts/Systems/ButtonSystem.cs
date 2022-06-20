using Components;
using Leopotam.EcsLite;
using UnityEngine;
using Utils;

namespace Systems
{
    public class ButtonSystem : IEcsInitSystem, IEcsRunSystem
    {
        private GameData gameData;
        
        public void Init(EcsSystems systems)
        {
            gameData = systems.GetShared<GameData>();
        }
        
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerComponent>().End();
            var playerComponents = world.GetPool<PlayerComponent>();
            foreach (int entity in filter)
            {
                ref var playerComponent = ref playerComponents.Get(entity);
                foreach (var door in gameData.Doors)
                {
                    if (Vector3.Distance(playerComponent.Transform.localPosition, door.button.transform.localPosition) <= 0.3f)
                    {
                        door.door.transform.localPosition = Vector3.MoveTowards(door.door.transform.localPosition, new Vector3(), 0.5f * Time.deltaTime);
                    }
                    else
                    {
                        if (door.door.transform.position != new Vector3())
                        {
                            door.door.transform.localPosition = Vector3.MoveTowards(door.door.transform.localPosition, new Vector3(0.5f,0,0), 
                                0.5f * Time.deltaTime);
                        }
                    }
                }
            }
        }
    }
}