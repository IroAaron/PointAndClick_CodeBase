using CodeBase.Infrastrusture.States;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {   
        public LoadingCurtain Curtain;
        public FadingScreen FadingScreen;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Curtain, FadingScreen);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}