using CodeBase.UnityComponents.UI.InventoryLogic;

namespace CodeBase.UnityComponents.Gameobject.Triggers
{
    public interface ITriggerLogic
    {
        bool Activate(Item item = null);

        void Processing();

        void Deactivate();
    }
}