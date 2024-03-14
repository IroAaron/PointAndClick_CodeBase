using System;
using UnityEngine.InputSystem;

namespace CodeBase.UnityComponents
{
    public interface IInteractable
    {
        void Interact();
        void Hold();
        void EndInteraction();
    }
}