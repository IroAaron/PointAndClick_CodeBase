using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class GameobjectManipulatorLogic : TriggerLogic
    {
        [SerializeField]
        private List<GameObject> _gameObjects;
        [SerializeField]
        private ActivationType _activationType;

        public override void Processing()
        {
            base.Processing();
            foreach (GameObject gameObject in _gameObjects)
            {
                switch (_activationType)
                {
                    case ActivationType.Activate:
                        gameObject.SetActive(true);
                        break;
                    case ActivationType.Deactivate: 
                        gameObject.SetActive(false); 
                        break;
                }
            }
        }
    }
}