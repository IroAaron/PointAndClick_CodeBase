using CodeBase.UnityComponents.UI.InventoryLogic;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class InteractionWithKeyLogic : TriggerLogic
    {
        [SerializeField]
        private string _keyName;

        public override bool Activate(Item item)
        {
            Debug.Log(gameObject.name + " Logic Activated");
            if (item == null)
            {
                return false;
            }
            else
            {
                if (item.ItemName == _keyName)
                {
                    Processing();
                    Deactivate();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}