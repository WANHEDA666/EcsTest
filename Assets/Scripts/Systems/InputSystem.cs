using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class InputSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<PlayerComponent>().End();
            var inputComponentPool = world.GetPool<InputComponent>();

            if (Input.GetMouseButtonDown(1))
            {
                var screenPosition = Input.mousePosition;
                screenPosition.z = Camera.main.nearClipPlane + 1;
                foreach (int entity in filter)
                {
                    ref var inputComponent = ref inputComponentPool.Get(entity);
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    var hit = new RaycastHit();
                    if (Physics.Raycast (ray, out hit))
                    {
                        inputComponent.XDirection = hit.point.x;
                        inputComponent.ZDirection = hit.point.z;
                    }
                }
            }
        }
    }
}