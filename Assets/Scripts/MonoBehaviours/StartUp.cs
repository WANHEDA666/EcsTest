using Systems;
using Leopotam.EcsLite;
using UnityEngine;

namespace MonoBehaviours
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private PlayerView playerView;
        [SerializeField] private InputView inputView;
        [SerializeField] private DoorsView doorsView;
        private EcsWorld _world;
        private EcsSystems updateSystems;
        private GameData gameData;

        private void Start()
        {
            _world = new EcsWorld();
            gameData = new GameData {PlayerView = playerView, InputView  = inputView, DoorsView = doorsView};
            updateSystems = new EcsSystems(_world, gameData)
                .Add(new PlayerSystem())
                .Add(new DoorsSystem())
                .Add(new InputSystem());
            updateSystems.Init();
        }

        private void Update()
        {
            updateSystems.Run();
        }
    }
}