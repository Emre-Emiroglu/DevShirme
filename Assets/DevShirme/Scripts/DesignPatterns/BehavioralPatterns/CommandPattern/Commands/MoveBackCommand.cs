using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.BehavioralPatterns.CommandPattern
{
    public class MoveBackCommand : Command
    {
        #region Fields
        private MoveObject moveObject;
        #endregion

        #region Constructor
        public MoveBackCommand(MoveObject moveObject)
        {
            this.moveObject = moveObject;
        }
        #endregion

        #region Executes
        public override void Execute()
        {
            moveObject.MoveBack();
        }
        public override void Undo()
        {
            moveObject.MoveForward();
        }
        #endregion
    }
}
