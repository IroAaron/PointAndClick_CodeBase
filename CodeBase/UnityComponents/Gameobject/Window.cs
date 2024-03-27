using CodeBase.UnityComponents.Gameobject.Triggers;
using CodeBase.UnityComponents.Player;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject
{
    public class Window : MonoBehaviour
    {
        public Window PreviousWindow;
        [SerializeField]
        private List<ActivationTrigger> _windowTriggers;

        public void OpenWindow()
        {
            FindFirstObjectByType<PlayerUtilities>().CurrentWindow = this;

            GetComponent<Collider2D>().enabled = true;

            if (_windowTriggers.Count == 0)
            {
                _windowTriggers = new List<ActivationTrigger>(GetComponentsInChildren<ActivationTrigger>());
            }

            foreach (var trigger in _windowTriggers)
            {
                trigger.gameObject.SetActive(true);
            }
        }

        public void OpenNextWindow()
        {
            GetComponent<Collider2D>().enabled = false;

            foreach (var trigger in _windowTriggers)
            {
                trigger.gameObject.SetActive(false);
            }
        }

        public void CloseWindow()
        {
            if (PreviousWindow == null)
            {
                transform.parent.GetComponent<Room>().ExitWindowMode();
            }
            else
            {
                PreviousWindow.OpenWindow();
            }

            gameObject.SetActive(false);
        }
    }
}