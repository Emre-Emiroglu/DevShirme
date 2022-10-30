using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.FSM
{
    public class StateMachine : DevShirmeManager
    {
        #region Fields
        private State currentState;
        #endregion

        #region Core
        public override void Initialize()
        {
        }
        #endregion

        #region Transations
        public void ToNewState(State newState)
        {
            currentState?.OnExit();
            currentState = newState;
            currentState.OnEnter();
        }
        #endregion

        #region Update
        private void Update()
        {
            currentState?.OnLogicUpdate();
        }
        private void FixedUpdate()
        {
            currentState?.OnPhysicUpdate();
        }
        #endregion
    }
}
