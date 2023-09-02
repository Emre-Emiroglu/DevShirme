using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IObserver
    {
        public void OnNotify(object value, Enums.NotificationType notificationType);
    }
}
