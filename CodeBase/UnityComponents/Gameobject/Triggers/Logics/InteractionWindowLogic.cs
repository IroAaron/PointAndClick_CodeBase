using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class InteractionWindowLogic : TriggerLogic
    {
        [SerializeField]
        private Window _window;

        private Room _room;

        public override void Processing()
        {
            base.Processing();

            _room = GetComponentInParent<Room>();
            _room.EnterWindowMode();

            _window.transform.position = _room.transform.position;
            _window.gameObject.SetActive(true);
            _window.OpenWindow();

            transform.parent.TryGetComponent(out Window parentWindow);
            if (parentWindow)
            {
                _window.PreviousWindow = parentWindow;
                parentWindow.OpenNextWindow();
            }

            Deactivate();
        }
    }
}