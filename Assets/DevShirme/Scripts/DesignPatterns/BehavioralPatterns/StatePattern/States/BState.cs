using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.BehavioralPatterns.StatePattern
{
    public class BState : State
    {
        #region Constructor
        public BState(StateMachine sm) : base(sm)
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
