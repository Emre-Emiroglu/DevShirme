using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Module: IObserver, ITickable, IFixedTickable, ILateTickable
    {
        #region Core
        public Module()
        {
        }
        #endregion

        #region Observer
        public abstract void OnNotify(object value, Enums.NotificationType notificationType);
        #endregion

        #region Ticks
        public abstract void Tick();
        public abstract void FixedTick();
        public abstract void LateTick();
        #endregion
    }
}
