using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers
{
    public class ActivationTrigger : MonoBehaviour, IInteractable
    {
        public Trigger ProcessingTrigger;
        public List<Trigger> logics;

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
                    ProcessingTrigger.Activate();
                }
                else
                {
                    EndInteraction();
                }
            }
        }

        public void Interact()
        {
            ProcessingTrigger = logics[0];
            ProcessingTrigger.Activate();
        }

        public void Hold()
        {
            
        }

        public void EndInteraction()
        {
            ProcessingTrigger = null;
        }
    }
}