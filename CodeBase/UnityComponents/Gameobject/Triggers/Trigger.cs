using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers
{
    public abstract class Trigger : MonoBehaviour, ITriggerLogic
    {
        public int Priority;
        public bool IsInProcess;

        public virtual void Activate()
        {
            Debug.Log(gameObject.name + " Logic Activated");
            IsInProcess = true;
            Processing();
        }

        public virtual void Processing()
        {
            Debug.Log(gameObject.name + " In Process");
        }

        public virtual void Deactivate()
        {
            Debug.Log(gameObject.name + " Logic Deactivated");
            IsInProcess = false;
        }
    }
}