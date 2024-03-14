using CodeBase.Infrastrusture.Services;
using System;
using UnityEngine;

namespace CodeBase.UnityComponents.Player
{
    public class PlayerInteraction : MonoBehaviour, IPlayerLogics
    {
        private PlayerUtilities _playerUtilities;
        private InputService _input;
        private IInteractable _interactableObject;

        public void Inject(PlayerUtilities playerUtilities)
        {
            _playerUtilities = playerUtilities;
            _input = _playerUtilities.Input;
        }

        private void Update()
        {
            if (_input.LeftMousePressed())
            {
                _interactableObject = GetInteractableObject();
                _interactableObject?.Interact();

                _playerUtilities.Inventory.CloseItemInfo();
            }

            if (_input.LeftMouseHold()) 
            {
                _interactableObject?.Hold();
            }

            if (_input.LeftMouseReleased())
            {
                _interactableObject = null;
            }

            if (_input.RightMousePressed())
            {
                _playerUtilities.Inventory.CloseItemInfo();
                _playerUtilities.Inventory.ExamingItem?.OpenItemInfo();
            }
        }

        private IInteractable GetInteractableObject()
        {
            Collider2D hitedObject = ShootRay().collider;

            if (hitedObject != null && hitedObject.TryGetComponent<IInteractable>(out IInteractable interactableObject))
            {
                Debug.Log(hitedObject.name);
                return interactableObject;
            }
            else
            {
                return null;
            }
        }

        private RaycastHit2D ShootRay()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            Vector3 worldPosition = GetComponent<Camera>().ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector3.forward);

            return hit;
        }
    }
}