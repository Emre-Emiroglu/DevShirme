using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface ISubject
    {
        public void Attach(IObserver observer);
        public void DeAttach(IObserver observer);
        public void Notify(object value, Enums.NotificationType notificationType);
    }
}
