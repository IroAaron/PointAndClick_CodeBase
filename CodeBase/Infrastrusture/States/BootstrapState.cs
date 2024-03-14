using CodeBase.Infrastructure;
using CodeBase.Infrastrusture.AssetManagment;
using CodeBase.Infrastrusture.Factory;
using CodeBase.Infrastrusture.Services;

namespace CodeBase.Infrastrusture.States
{
    public class BootstrapState : IState
    {
        private const string BootScene = "Boot";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _allServices;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices allServices)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _allServices = allServices;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(BootScene, EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("Prologue");
        }

        private void RegisterServices()
        {
            _allServices.RegisterSingle<IAssets>(new AssetProvider());
            _allServices.RegisterSingle<IService>(new InputService(new GameInput()));
            _allServices.RegisterSingle<IGameFactory>(new GameFactory(AllServices.Container.Single<IAssets>()));
        }

        public void Exit()
        {
            
        }
    }
}