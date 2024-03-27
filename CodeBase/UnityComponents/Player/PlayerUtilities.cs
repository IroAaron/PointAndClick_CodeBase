using CodeBase.Infrastrusture.Services;
using CodeBase.UnityComponents.Gameobject;
using CodeBase.UnityComponents.UI;
using CodeBase.UnityComponents.UI.InventoryLogic;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UnityComponents.Player
{
    public class PlayerUtilities : MonoBehaviour
    {
        public Inventory Inventory;
        public Journal Journal;
        public Room CurrentRoom;
        public Window CurrentWindow;

        public InputService Input;

        private void Awake()
        {
            Input = AllServices.Container.Single<IService>() as InputService;

            if(Input == null)
            {
                Input = new InputService(new GameInput());
            }

            InjectUtilities();
        }

        private void InjectUtilities()
        {
            List<IPlayerLogics> playerLogics = new List<IPlayerLogics>(GetComponentsInChildren<IPlayerLogics>());

            foreach (var playerLogic in playerLogics)
            {
                playerLogic.Inject(this);
            }
        }
    }
}