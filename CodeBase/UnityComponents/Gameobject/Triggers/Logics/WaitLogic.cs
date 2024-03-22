using CodeBase.UnityComponents.Gameobject.Triggers;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class WaitLogic : TriggerLogic
    {
        [SerializeField]
        private float _seconds;

        public override void Processing()
        {
            base.Processing();
            StartCoroutine(Enumerator());
        }

        public IEnumerator Enumerator()
        {
            yield return new WaitForSeconds(_seconds);

            Deactivate();
        }
    }
}