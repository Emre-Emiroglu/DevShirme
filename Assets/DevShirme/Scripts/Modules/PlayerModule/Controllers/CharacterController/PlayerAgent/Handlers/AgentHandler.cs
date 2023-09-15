using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public abstract class AgentHandler
    {
        #region Fields
        protected Transform _obj;
        protected Rigidbody _rb;
        #endregion

        #region Core
        protected AgentHandler(Transform obj, Rigidbody rb)
        {
            _obj = obj;
            _rb = rb;
        }
        public abstract void Execute(Vector2 input, Enums.KeyCodeState keyCodeState);
        #endregion
    }
}
