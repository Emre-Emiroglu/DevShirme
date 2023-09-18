using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.Behaviorals
{
    public class NotActionSubject : Subject
    {
        #region Core
        public NotActionSubject(Structs.SubjectData _data) : base(_data)
        {
            this._data.Observers = new HashSet<IObserver>();
        }
        public override void Attach(IObserver observer)
        {
            _data.Observers.Add(observer);
        }
        public override void DeAttach(IObserver observer)
        {
            _data.Observers.Remove(observer);
        }
        public override void Notify(object value)
        {
            foreach (IObserver item in _data.Observers)
                item.OnNotify(value, _data.NotificationType);
        }
        #endregion
    }
}
