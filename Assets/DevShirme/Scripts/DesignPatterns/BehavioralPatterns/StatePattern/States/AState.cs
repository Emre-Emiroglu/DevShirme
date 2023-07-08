using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.BehavioralPatterns.StatePattern
{
    public class AState : State
    {
        #region Constructor
        public AState(StateMachine sm) : base(sm)
        {
        }
        #endregion

        #region Core
        public override void OnEnter()
        {
        }
        public override void OnExit()
        {
        }
        public override void OnLogicUpdate()
        {
        }
        public override void OnPhysicUpdate()
        {
        }
        #endregion
    }
}
