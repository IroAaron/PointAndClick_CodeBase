using CodeBase.UnityComponents.Gameobject.Triggers;
using CodeBase.UnityComponents.UI.InventoryLogic;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject
{
    public class Room : MonoBehaviour
    {
        public List<ActivationTrigger> _interactableTriggers;
        private ActivationTrigger _firstWindowTrigger;
        private void Start()
        {
            _interactableTriggers = new List<ActivationTrigger>(GetComponentsInChildren<ActivationTrigger>());
        }

        public void EnterWindowMode()
        {
            foreach (ActivationTrigger trigger in _interactableTriggers)
            {
                trigger.gameObject.SetActive(false);
            }
        }

        public void ExitWindowMode()
        {
            foreach (ActivationTrigger trigger in _interactableTriggers)
            {
                trigger.gameObject.SetActive(true);
            }
        }
    }
}