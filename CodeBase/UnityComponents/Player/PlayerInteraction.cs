using CodeBase.Infrastrusture.Services;
using CodeBase.UnityComponents.UI.InventoryLogic;
using System.Linq;
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
                if(_playerUtilities.Inventory.ActiveItem != null)
                {
                    _interactableObject = GetInteractableObject();
                    _interactableObject.Interact(_playerUtilities.Inventory.ActiveItem as Item);
                }

                _playerUtilities.Inventory.ActiveItem?.DropItem();

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
            Collider2D hitedObject = ShootRays();

            if (hitedObject != null && hitedObject.TryGetComponent(out IInteractable interactableObject))
            {
                Debug.Log(hitedObject.name);
                return interactableObject;
            }
            else
            {
                return null;
            }
        }

        private Collider2D ShootRays()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            Vector3 worldPosition = GetComponent<Camera>().ScreenToWorldPoint(mousePos);
            RaycastHit2D[] hitTriggers = Physics2D.RaycastAll(worldPosition, Vector3.forward);

            foreach (var hitTrigger in hitTriggers)
            {
                if (hitTrigger.collider.TryGetComponent(out IInteractable trigger))
                {
                    return hitTrigger.collider;
                }
            }

            if(hitTriggers.Length == 0)
            {
                _playerUtilities.CurrentWindow?.CloseWindow();
            }

            return null;
        }
    }
}