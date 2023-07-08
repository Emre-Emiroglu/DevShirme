using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.BehavioralPatterns.StatePattern
{
    public class State
    {
        #region Fields
        protected StateMachine sm;
        #endregion

        #region Contructor
        public State(StateMachine sm)
        {
            this.sm = sm;
        }
        #endregion

        #region Core
        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnLogicUpdate() { }
        public virtual void OnPhysicUpdate() { }
        #endregion
    }
}
