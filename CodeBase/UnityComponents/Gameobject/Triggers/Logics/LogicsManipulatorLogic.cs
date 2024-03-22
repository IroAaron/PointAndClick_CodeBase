using UnityEngine;

namespace CodeBase.UnityComponents.Gameobject.Triggers.Logics
{
    public class LogicsManipulatorLogic : TriggerLogic
    {
        [SerializeField]
        private ActivationTrigger _activationTrigger;
        [SerializeField]
        private ActivationType _activationType;
        [SerializeField]
        private string _logicName;

        public override void Processing()
        {
            base.Processing();

            switch (_activationType)
            {
                case ActivationType.Activate:
                    ActivateLogic();
                    break;
                case ActivationType.Deactivate:
                    DeactivateLogic();
                    break;
            }

            base.Deactivate();
        }

        public void ActivateLogic()
        {
            ForeachLogics().IsEnable = true;
        }

        public void DeactivateLogic()
        {
            ForeachLogics().IsEnable = false;
        }

        public TriggerLogic ForeachLogics()
        {
            foreach (TriggerLogic logic in _activationTrigger.Logics)
            {
                if (logic.LogicName == _logicName)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}