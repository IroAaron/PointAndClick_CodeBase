using CodeBase.Infrastrusture.Services;
using CodeBase.Infrastrusture.States;
using CodeBase.Logic;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, FadingScreen fadingScreen)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, fadingScreen, AllServices.Container);
        }
    }
}