using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.BehavioralPatterns.CommandPattern
{
    public abstract class Command
    {
        #region Executes
        public abstract void Execute();
        public abstract void Undo();
        #endregion
    }
}
