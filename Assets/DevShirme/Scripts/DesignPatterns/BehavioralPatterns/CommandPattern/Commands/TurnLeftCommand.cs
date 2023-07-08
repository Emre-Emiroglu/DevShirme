using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.BehavioralPatterns.CommandPattern
{
    public class TurnLeftCommand : Command
    {
        #region Fields
        private MoveObject moveObject;
        #endregion

        #region Constructor
        public TurnLeftCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }
        #endregion

        #region Executes
        public override void Execute()
        {
            moveObject.TurnLeft();
        }
        public override void Undo()
        {
            moveObject.TurnRight();
        }
        #endregion
    }
}
