using CodeBase.Infrastrusture.Services;
using CodeBase.UnityComponents.UI.InventoryLogic;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers
{
    public class ActivationTrigger : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private TriggerLogic _processingTrigger;
        public List<TriggerLogic> Logics { get; private set; }
        private Item _key;
        private InputService _inputService;

        private void Start()
        {
            _inputService = AllServices.Container.Single<IService>() as InputService;

            if (_inputService == null)
            {
                _inputService = new InputService(new GameInput());
            }

            Logics = new List<TriggerLogic>(GetComponents<TriggerLogic>());

            Logics = Logics.OrderBy(logic => logic.Priority).ToList();
        }

        private void Update()
        {
            if (_processingTrigger)
            {
                if (_processingTrigger.IsInProcess)
                {
                    return;
                }

                if (Logics.IndexOf(_processingTrigger) != Logics.Count - 1)
                {
                    if (Logics[Logics.IndexOf(_processingTrigger) + 1].IsEnable == false)
                    {
                        _processingTrigger = Logics[Logics.IndexOf(_processingTrigger) + 1];
                        return;
                    }
                    else
                    {
                        _processingTrigger = Logics[Logics.IndexOf(_processingTrigger) + 1];
                    }

                    if (_processingTrigger.Activate(_key) == false)
                    {
                        EndInteraction();
                    }
                }
                else
                {
                    EndInteraction();
                }
            }
        }

        public void Interact(Item item = null)
        {
            _inputService.DeactivateGameplay();

            _processingTrigger = Logics[0];
            _key = item;
            if (_processingTrigger.Activate(_key) == false)
            {
                _processingTrigger = null;
            }
        }

        public void EndInteraction()
        {
            _inputService.ActivateGameplay();
            _processingTrigger = null;
            _key = null;
        }
    }
}