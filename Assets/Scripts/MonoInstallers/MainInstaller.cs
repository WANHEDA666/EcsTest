using Systems;
using MonoBehaviours;
using Zenject;

namespace MonoInstallers
{
    public class MainInstaller : MonoInstaller
    {
        public PlayerView playerView;
        public LockView[] locksView;

        public override void InstallBindings()
        {
            Container.Bind<PlayerView>().FromInstance(playerView).AsSingle().NonLazy();
            Container.Bind<LockView[]>().FromInstance(locksView).AsSingle().NonLazy();
            
            var lockSystem = Container.Instantiate(typeof(LockSystem)) as LockSystem;
            Container.Bind<LockSystem>().FromInstance(lockSystem);
            
            var playerSystem = Container.Instantiate(typeof(PlayerSystem)) as PlayerSystem;
            Container.Bind<PlayerSystem>().FromInstance(playerSystem);
        }
    }
}