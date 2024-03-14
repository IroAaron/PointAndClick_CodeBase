using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CodeBase.UnityComponents.UI.InventoryLogic
{
    public class Inventory : MonoBehaviour, IUIObject
    {
        private GameplayCanvas _gameplayCanvas;
        public InventoryContent ActiveItem;
        public InventoryContent ExamingItem;
        public List<InventoryContent> Items;
        public GameObject ItemExamSprite;
        public TextMeshProUGUI ItemDescriptionTxt;

        public void Inject(GameplayCanvas gameplayCanvas)
        {
            _gameplayCanvas = gameplayCanvas;
            
            foreach (var item in Items)
            {
                item?.Inject(this);
            }
        }

        public void AddItem(InventoryContent inventoryContent)
        {
            Items.Add(inventoryContent);

            inventoryContent.Inject(this);
        }

        public void RemoveItem(InventoryContent inventoryContent)
        {
            Items.Remove(inventoryContent);

            Destroy(inventoryContent.gameObject);
        }

        public void CloseItemInfo()
        {
            ItemDescriptionTxt.gameObject.SetActive(false);
            ItemExamSprite.SetActive(false);
        }
    }
}