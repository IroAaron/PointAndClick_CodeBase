using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers
{
    public class InteractionTrigger : Trigger
    {
        public string TestMessage;

        public override void Processing()
        {
            base.Processing();
            Debug.Log(TestMessage +" "+ Priority);
            Deactivate();
        }
    }
}