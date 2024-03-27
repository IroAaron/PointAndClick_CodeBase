using CodeBase.UnityComponents.UI.InventoryLogic;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Containers
{
    [CreateAssetMenu(fileName = "Item Container", menuName = "Containers/Create Item Container", order = 0)]
    public class ItemContainer : ScriptableObject
    {
        [SerializeField]
        public List<InventoryContent> Items = new List<InventoryContent>();
    }
}