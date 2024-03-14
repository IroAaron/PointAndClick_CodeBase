using CodeBase.Infrastrusture.Services;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CodeBase.UnityComponents.UI.InventoryLogic
{
    public class InventoryContent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
        IPointerUpHandler, IDragHandler, IInventoryContent
    {
        private Inventory _inventory;
        public Transform Canvas;

        public string ItemName;

        public Transform ItemSlot;
        public GameObject ItemSprite;

        public string ItemShownName;
        public TextMeshProUGUI ItemShownNameTxt;

        [TextArea]
        public string ItemDescription;
        public Sprite ItemExamSprite;
        private TextMeshProUGUI _itemDescriptionTxt;
        private GameObject _itemExamSpriteGO;

        public void Inject(Inventory inventory)
        {
            _inventory = inventory;

            ItemShownNameTxt.gameObject.SetActive(false);
            ItemShownNameTxt.text = ItemShownName;

            _itemDescriptionTxt = _inventory.ItemDescriptionTxt;
            _itemExamSpriteGO = _inventory.ItemExamSprite;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _inventory.ExamingItem = this;
            ItemShownNameTxt.gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _inventory.ExamingItem = null;
            ItemShownNameTxt.gameObject.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Left)
                ItemSprite.transform.parent = _inventory.gameObject.transform.parent;
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Vector2 mousePosotion = Input.mousePosition;
                ItemSprite.transform.position = mousePosotion;
                _inventory.ActiveItem = this;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ItemSprite.transform.position = ItemSlot.position;
            _inventory.ActiveItem = null;

            ItemSprite.transform.parent = ItemSlot;
        }

        public void OpenItemInfo()
        {
            ItemShownNameTxt.text = ItemShownName;
            _itemDescriptionTxt.text = ItemDescription;

            if (ItemExamSprite != null)
            {
                _itemExamSpriteGO.GetComponent<Image>().sprite = ItemExamSprite;
            }
            else
            {
                _itemExamSpriteGO.GetComponent<Image>().sprite = ItemSprite.GetComponent<Image>().sprite;
            }

            _itemDescriptionTxt.gameObject.SetActive(true);
            _itemExamSpriteGO.SetActive(true);
        }
    }
}