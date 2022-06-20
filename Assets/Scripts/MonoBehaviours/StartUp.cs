using Systems;
using Leopotam.EcsLite;
using UnityEngine;
using Utils;

namespace MonoBehaviours
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Door[] doors;
        private EcsWorld _world;
        private EcsSystems _updateSystems;
        private GameData gameData;

        private void Start()
        {
            _world = new EcsWorld();
            gameData = new GameData {Transform = playerTransform, Doors = doors};
            _updateSystems = new EcsSystems(_world, gameData)
                .Add(new PlayerSystem())
                .Add(new ButtonSystem())
                .Add(new InputSystem());
            _updateSystems.Init();
        }

        private void Update()
        {
            _updateSystems.Run();
        }
    }
}