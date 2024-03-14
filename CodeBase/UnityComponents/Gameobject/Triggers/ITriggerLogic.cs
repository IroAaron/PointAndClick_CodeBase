using System;

namespace CodeBase.UnityComponents.Gameobject.Triggers
{
    public interface ITriggerLogic
    {
        void Activate();

        void Processing();

        void Deactivate();
    }
}