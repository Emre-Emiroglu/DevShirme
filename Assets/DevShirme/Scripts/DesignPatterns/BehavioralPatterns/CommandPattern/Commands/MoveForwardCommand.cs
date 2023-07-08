using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.BehavioralPatterns.CommandPattern
{
    public class MoveForwardCommand : Command
    {
        #region Fields
        private MoveObject moveObject;
        #endregion

        #region Constructor
        public MoveForwardCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }
        #endregion

        #region Executes
        public override void Execute()
        {
            moveObject.MoveForward();
        }
        public override void Undo()
        {
            moveObject.MoveBack();
        }
        #endregion
    }
}
