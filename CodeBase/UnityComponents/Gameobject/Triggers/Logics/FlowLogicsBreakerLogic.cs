using CodeBase.UnityComponents.UI.InventoryLogic;
using System.Collections;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class FlowLogicsBreakerLogic : TriggerLogic
    {
        public override bool Activate(Item item = null)
        {
            return false;
        }
    }
}