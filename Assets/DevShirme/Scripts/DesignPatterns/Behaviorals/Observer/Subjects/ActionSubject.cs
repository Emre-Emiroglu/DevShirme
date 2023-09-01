using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.DesignPatterns.Behaviorals
{
    public class ActionSubject : Subject
    {
        #region Core
        public ActionSubject(Structs.SubjectData _data) : base(_data)
        {
        }
        public override void Attach(IObserver observer)
        {
            _data.Action += observer.OnNotify;
        }
        public override void DeAttach(IObserver observer)
        {
            _data.Action -= observer.OnNotify;
        }
        public override void Notify(object value, Enums.NotificationType notificationType)
        {
            _data.Action.Invoke(value, notificationType);
        }
        #endregion
    }
}
