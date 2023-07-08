using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.BehavioralPatterns.StatePattern
{
    public class StateMachine
    {
        #region Fields
        public enum StateType: int
        {
            A = 0,
            B = 1,
            MAX = 2
        }
        private State[] states;
        private State currentState;
        #endregion

        #region Constructor
        public StateMachine()
        {
            states = new State[((int)StateType.MAX)];

            for (int i = 0; i < ((int)StateType.MAX); i++)
                states[i] = new State(this);

            ToNewState(StateType.A);
        }
        #endregion

        #region Executes
        public void ToNewState(StateType stateType)
        {
            currentState?.OnExit();
            currentState = states[((int)stateType)];
            currentState?.OnEnter();
        }
        public void ExternalUpdate() => currentState?.OnLogicUpdate();
        public void ExternalFixedUpdate() => currentState?.OnPhysicUpdate();
        #endregion
    }
}
