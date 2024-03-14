﻿using CodeBase.UnityComponents.UI.InventoryLogic;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers
{
    public abstract class Trigger : MonoBehaviour, ITriggerLogic
    {
        public int Priority;
        public bool IsInProcess;

        public virtual bool Activate(Item item = null)
        {
            Debug.Log(gameObject.name + " Logic Activated");
            Processing();
            return true;
        }

        public virtual void Processing()
        {
            IsInProcess = true;
            Debug.Log(gameObject.name + " In Process");
        }

        public virtual void Deactivate()
        {
            Debug.Log(gameObject.name + " Logic Deactivated");
            IsInProcess = false;
        }
    }
}