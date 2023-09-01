using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.Behaviorals
{
    public class Observer : IObserver
    {
        #region Core
        public Observer()
        { 
        }
        public void OnNotify(object value, Enums.NotificationType notificationType)
        {
        }
        #endregion
    }
}
