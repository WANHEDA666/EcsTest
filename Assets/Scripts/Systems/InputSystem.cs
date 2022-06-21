using Components;
using Interfaces;
using Leopotam.EcsLite;

namespace Systems
{
    public class InputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private IInputView inputView;
        
        public void Init(EcsSystems systems)
        {
            var gameData = systems.GetShared<GameData>();
            inputView = gameData.InputView;
        }
        
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var inputComponentPool = world.GetPool<InputComponent>();
            ref var inputComponent = ref inputComponentPool.Get(0);
            inputComponent.XDirection = inputView.GetMouseCoordinates().XPosition;
            inputComponent.ZDirection =  inputView.GetMouseCoordinates().ZPosition;
        }
    }
}