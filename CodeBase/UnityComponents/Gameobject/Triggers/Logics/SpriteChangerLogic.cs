using CodeBase.UnityComponents.Gameobject.Triggers;
using UnityEngine;

namespace Assets.CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class SpriteChangerLogic : TriggerLogic
    {
        [SerializeField]
        private SpriteRenderer _gameobject;
        [SerializeField]
        private Sprite _newSprite;

        public override void Processing()
        {
            base.Processing();
            ChangeSprite();
            Deactivate();
        }

        private void ChangeSprite()
        {
            _gameobject.sprite = _newSprite;
        }
    }
}