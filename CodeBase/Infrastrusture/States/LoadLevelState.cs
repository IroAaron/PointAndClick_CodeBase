using CodeBase.Infrastructure;
using CodeBase.Infrastrusture.Factory;
using CodeBase.Logic;
using CodeBase.UnityComponents.Player;
using CodeBase.UnityComponents.UI;
using CodeBase.UnityComponents.UI.InventoryLogic;
using UnityEngine;

namespace CodeBase.Infrastrusture.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly FadingScreen _fadingScreen;
        private readonly IGameFactory _gameFactory;
        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain,
        FadingScreen fadingScreen, IGameFactory gameFactory)
        {
            _curtain = curtain;
            _fadingScreen = fadingScreen;
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            // TODO: вставить в плеера GameplayCanvas, а значит сначала загружать уроветь с GameplayUI            
            GameObject player = _gameFactory.CreatePlayer(GameObject.FindWithTag(InitialPointTag));
            player.GetComponent<PlayerUtilities>().Inventory = 
                _gameFactory.CreateInventory(_fadingScreen).GetComponent<GameplayCanvas>().injectionGameplayCanvasObjects as Inventory;

            player.GetComponent<PlayerUtilities>().Journal =
                _gameFactory.CreateJournal(_fadingScreen).GetComponent<GameplayCanvas>().injectionGameplayCanvasObjects as Journal;

            _stateMachine.Enter<GameLoopState>();
        }
    }
}