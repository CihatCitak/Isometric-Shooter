using UnityEngine;

namespace States
{
    public abstract class StateManager : MonoBehaviour
    {
        public IState CurrentState;

        void Start()
        {
            Init();
        }

        private void FixedUpdate()
        {
            CurrentState.StateUpdate();
        }

        public virtual void SwitchState(IState state)
        {
            CurrentState = state;

            CurrentState.StateEnter();
        }

        public virtual void Init()
        {
            CurrentState.StateEnter();
        }
    }
}

