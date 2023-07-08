using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.BehavioralPatterns.CommandPattern
{
    public class TurnRightCommand : Command
    {
        #region Fields
        private MoveObject moveObject;
        #endregion

        #region Constructor
        public TurnRightCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }
        #endregion

        #region Executes
        public override void Execute()
        {
            moveObject.TurnRight();
        }
        public override void Undo()
        {
            moveObject.TurnLeft();
        }
        #endregion
    }
}
