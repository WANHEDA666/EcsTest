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
            var inputComponentPool = world.GetPool<InputComponent>();
            ref var inputComponent = ref inputComponentPool.Get(0);
            if (Input.GetMouseButtonDown(1))
            {
                var screenPosition = Input.mousePosition;
                screenPosition.z = Camera.main.nearClipPlane + 1;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    var xDirection = hit.point.x;
                    var zDirection = hit.point.z;
                    inputComponent.Position = new SimpleVector2(xDirection, zDirection);
                }
            }
        }
    }
}