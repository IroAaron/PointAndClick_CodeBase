using CodeBase.UnityComponents.UI.InventoryLogic;
using System.Collections;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers
{
    public class InteractionWithKey : Trigger
    {
        public string KeyName;

        public override bool Activate(Item item)
        {
            Debug.Log(gameObject.name + " Logic Activated");
            if(item == null)
            {
                return false;
            }
            else
            {
                if (item.ItemName == KeyName)
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