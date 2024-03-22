using System.Collections;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class TestInteractionTrigger : TriggerLogic
    {
        [SerializeField]
        private string _testMessage;

        public override void Processing()
        {
            base.Processing();
            Debug.Log(_testMessage + " " + Priority);
            Deactivate();
        }
    }
}