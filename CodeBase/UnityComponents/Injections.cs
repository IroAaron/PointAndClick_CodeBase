using CodeBase.UnityComponents.Player;
using CodeBase.UnityComponents.UI;
using CodeBase.UnityComponents.UI.InventoryLogic;

namespace CodeBase.UnityComponents
{
    public interface Injections
    {
        void Inject();
    }

    public interface InjectionGameplayCanvas
    {
        void Inject(GameplayCanvas gameplayCanvas);
    }

    public interface InjectionInventory
    {
        void Inject(Inventory inventory);
    }

    public interface IPlayerLogics
    {
        void Inject(PlayerUtilities playerUtilities);
    }
}