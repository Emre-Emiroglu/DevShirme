using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.Behaviorals
{
    public abstract class Subject : ISubject
    {
        #region Fields
        protected Structs.SubjectData _data;
        #endregion

        #region Core
        public Subject(Structs.SubjectData _data)
        {
            this._data = _data;
        }
        public abstract void Attach(IObserver observer);
        public abstract void DeAttach(IObserver observer);
        public abstract void Notify(object value, Enums.NotificationType notificationType);
        #endregion
    }
}
