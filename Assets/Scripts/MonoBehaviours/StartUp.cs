using Systems;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace MonoBehaviours
{
    public class StartUp : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems updateSystems;
        private LockSystem lockSystem;
        private PlayerSystem playerSystem;
        
        [Inject]
        private void Construct(LockSystem lockSystem, PlayerSystem playerSystem)
        {
            this.lockSystem = lockSystem;
            this.playerSystem = playerSystem;
        }

        private void Start()
        {
            _world = new EcsWorld();
            
            updateSystems = new EcsSystems(_world)
                .Add(playerSystem)
                .Add(lockSystem)
                .Add(new InputSystem());
            updateSystems.Init();
        }

        private void Update()
        {
            updateSystems.Run();
        }
    }
}