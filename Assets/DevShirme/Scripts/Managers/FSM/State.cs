using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.FSM
{
    public class State
    {
        private StateMachine sm;
        #region Core
        public State(StateMachine sm)
        {
            this.sm = sm;
        }
        public virtual void OnEnter() { }
        public virtual void OnLogicUpdate() { }
        public virtual void OnPhysicUpdate() { }
        public virtual void OnExit() { }
        #endregion
    }
}
