using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public abstract class AgentHandler : IAgentHandler, IObserver
    {
        #region Fields
        protected Transform _obj;
        protected Rigidbody _rb;
        #endregion

        #region Core
        protected AgentHandler(ISubject subject, Transform obj, Rigidbody rb)
        {
            subject.Attach(this);

            _obj = obj;
            _rb = rb;
        }
        public abstract void ExternalUpdate();
        public abstract void ExternalFixedUpdate();
        public abstract void OnNotify(object value, Enums.NotificationType notificationType);
        #endregion
    }
}
