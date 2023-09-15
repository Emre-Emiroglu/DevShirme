using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Manager: ITickable, IFixedTickable, ILateTickable
    {
        #region Core
        public Manager()
        {
        }
        #endregion

        #region Ticks
        public abstract void Tick();
        public abstract void FixedTick();
        public abstract void LateTick();
        #endregion
    }
}
