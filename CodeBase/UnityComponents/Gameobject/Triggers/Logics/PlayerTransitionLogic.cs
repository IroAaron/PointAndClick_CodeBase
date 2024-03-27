using CodeBase.Logic;
using CodeBase.UnityComponents.Player;
using CodeBase.UnityComponents.UI.InventoryLogic;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class PlayerTransitionLogic : TriggerLogic
    {
        [SerializeField]
        private Room _room;
        [SerializeField]
        private float _transitionTime = 2f;

        private FadingScreen _fadingScreen;
        private Transform _player;

        public override bool Activate(Item item = null)
        {
            _player = Camera.main.transform;
            _fadingScreen = FindFirstObjectByType<FadingScreen>();
            return base.Activate(item);
        }

        public override void Processing()
        {
            base.Processing();
            _fadingScreen.Show(1, _transitionTime / 2, TransitePlayer);
        }

        private void TransitePlayer()
        {
            _player.position = new Vector3(_room.transform.position.x, _room.transform.position.y, -10);
            _player.GetComponent<PlayerUtilities>().CurrentRoom = _room;
            _fadingScreen.Hide(_transitionTime / 2, Deactivate);
        }
    }
}