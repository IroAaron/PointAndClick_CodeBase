using CodeBase.Infrastrusture.Services;
using CodeBase.UnityComponents.UI.InventoryLogic;

namespace CodeBase.UnityComponents
{
    public interface IInteractable
    {
        void Interact(InputService inputService, Item item = null);
        void Hold();
        void EndInteraction();
    }
}