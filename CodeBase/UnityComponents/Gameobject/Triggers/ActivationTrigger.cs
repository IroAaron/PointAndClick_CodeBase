using Assets.CodeBase.UnityComponents.Gameobject.Triggers;
using Assets.CodeBase.UnityComponents.Gameobject.Triggers.Logics;
using CodeBase.Infrastrusture.Services;
using CodeBase.UnityComponents.UI.InventoryLogic;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers
{
    public class ActivationTrigger : MonoBehaviour, IInteractable
    {
        public TriggerLogic ProcessingTrigger;
        public List<TriggerLogic> Logics;
        private Item _key;
        private InputService _inputService;

        private void Start()
        {
            Logics = new List<TriggerLogic>(GetComponents<TriggerLogic>());

            Logics = Logics.OrderBy(logic => logic.Priority).ToList();
        }

        private void Update()
        {
            if (ProcessingTrigger)
            {
                if (ProcessingTrigger.IsInProcess)
                {
                    return;
                }

                if (Logics.IndexOf(ProcessingTrigger) != Logics.Count - 1)
                {
                    if (Logics[Logics.IndexOf(ProcessingTrigger) + 1].IsEnable == false)
                    {
                        ProcessingTrigger = Logics[Logics.IndexOf(ProcessingTrigger) + 1];
                        return;
                    }
                    else
                    {
                        ProcessingTrigger = Logics[Logics.IndexOf(ProcessingTrigger) + 1];
                    }

                    if (ProcessingTrigger.Activate(_key) == false)
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

        public void Interact(InputService inputService, Item item = null)
        {
            _inputService = inputService;
            _inputService.DeactivateGameplay();

            ProcessingTrigger = Logics[0];
            _key = item;
            if (ProcessingTrigger.Activate(_key) == false)
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
            _key = null;
        }
    }
}