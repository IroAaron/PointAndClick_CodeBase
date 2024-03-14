using CodeBase.Infrastrusture.Services;
using CodeBase.UnityComponents.UI.InventoryLogic;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers
{
    public class ActivationTrigger : MonoBehaviour, IInteractable
    {
        public Trigger ProcessingTrigger;
        public List<Trigger> logics;
        public Item Key;
        private InputService _inputService;

        private void Start()
        {
            logics = new List<Trigger>(GetComponents<Trigger>());

            logics = logics.OrderBy(logic => logic.Priority).ToList();
        }

        private void Update()
        {
            if (ProcessingTrigger)
            {
                while (ProcessingTrigger.IsInProcess)
                {
                    return;
                }

                if (logics.IndexOf(ProcessingTrigger) != logics.Count - 1)
                {
                    ProcessingTrigger = logics[logics.IndexOf(ProcessingTrigger) + 1];
                    if (ProcessingTrigger.Activate(Key) == false)
                    {
                        ProcessingTrigger = null;
                        EndInteraction();
                    }
                }
                else
                {
                    EndInteraction();
                }
            }
        }

        public void Interact(InputService inputService, Item item = null)
        {
            _inputService = inputService;
            _inputService.DeactivateGameplay();

            ProcessingTrigger = logics[0];
            Key = item;
            if (ProcessingTrigger.Activate(Key) == false)
            {
                ProcessingTrigger = null;
            }
        }

        public void Hold()
        {
            
        }

        public void EndInteraction()
        {
            _inputService.ActivateGameplay();
            ProcessingTrigger = null;
            Key = null;
        }
    }
}