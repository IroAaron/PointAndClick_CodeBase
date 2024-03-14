using UnityEngine;

namespace CodeBase.Infrastrusture.Services
{
    public class InputService : IService
    {
        private readonly GameInput _gameInput;

        public InputService(GameInput gameInput)
        {
            _gameInput = gameInput;

            ActivateGameplay();
        }

        public void ActivateGameplay()
        {
            _gameInput.Gameplay.Enable();
            Debug.Log("Gameplay Enabled");
        }

        public void DeactivateGameplay()
        {
            _gameInput.Gameplay.Disable();
            Debug.Log("Gameplay Disabled");
        }

        public bool LeftMousePressed() => _gameInput.Gameplay.LeftMouse.WasPressedThisFrame();
        public bool LeftMouseHold() => _gameInput.Gameplay.LeftMouse.IsPressed();
        public bool LeftMouseReleased() => _gameInput.Gameplay.LeftMouse.WasReleasedThisFrame();
        public bool RightMousePressed() => _gameInput.Gameplay.RightMouse.WasPressedThisFrame();
        public bool OpenMenuPressed() => _gameInput.Gameplay.OpenMenu.WasPressedThisFrame();
    }
}