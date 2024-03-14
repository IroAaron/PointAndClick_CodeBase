using System.Collections.Generic;
using CodeBase.UnityComponents.Player;
using CodeBase.UnityComponents.UI.InventoryLogic;

namespace CodeBase.UnityComponents.UI
{
    public interface Injections
    {
        void Inject();
    }

    public interface IUIObject
    {
        void Inject(GameplayCanvas gameplayCanvas);
    }

    public interface IInventoryContent
    {
        void Inject(Inventory inventory);
    }

    public interface IPlayerLogics
    {
        void Inject(PlayerUtilities playerUtilities);
    }
}