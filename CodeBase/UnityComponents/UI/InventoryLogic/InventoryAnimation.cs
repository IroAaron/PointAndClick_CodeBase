using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UnityComponents.UI.InventoryLogic
{
    public class InventoryAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private float ClosePositionX;
        public float OpenOffsetX;
        public float AnimationDuration;
        public Ease animEase;
        
        private void Start()
        {
            ClosePositionX = transform.position.x;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OpenInventory();
            Debug.Log("InventoryOpen");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CloseInventory();
            Debug.Log("InventoryClose");
        }

        public void OpenInventory()
        {
            transform.DOMoveX(ClosePositionX - OpenOffsetX, AnimationDuration).SetEase(animEase);
        }

        public void CloseInventory()
        {
            transform.DOMoveX(ClosePositionX, AnimationDuration).SetEase(animEase);
        }
    }
}