using System;
using Components;
using Interfaces;
using Leopotam.EcsLite;

namespace Systems
{
    public class DoorsSystem : IEcsInitSystem, IEcsRunSystem
    {
        private GameData gameData;
        private IDoorsView doorsView;
        
        public void Init(EcsSystems systems)
        {
            gameData = systems.GetShared<GameData>();
            doorsView = gameData.DoorsView;
        }
        
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerComponent>().End();
            var playerComponents = world.GetPool<PlayerComponent>();
            foreach (int entity in filter)
            {
                var playerComponent = playerComponents.Get(entity);
                for (int i = 0; i < doorsView.Doors.Length; i++)
                {
                    float num1 = playerComponent.Position.x - doorsView.Doors[i].button.transform.localPosition.x;
                    float num2 = playerComponent.Position.y - doorsView.Doors[i].button.transform.localPosition.y;
                    float num3 = playerComponent.Position.z - doorsView.Doors[i].button.transform.localPosition.z;
                    if ((float) Math.Sqrt(num1 * (double) num1 + num2 * (double) num2 + num3 * (double) num3) <= 0.3f)
                    {
                        doorsView.MoveDoor(i);
                    }
                }
            }
        }
    }
}