using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public abstract class AgentHandler
    {
        #region Fields
        protected Transform _obj;
        protected Rigidbody _rb;
        #endregion

        #region Props
        public Structs.InputData InputData { get; set; }
        #endregion

        #region Core
        protected AgentHandler(Transform obj, Rigidbody rb)
        {
            _obj = obj;
            _rb = rb;
        }
        #endregion

        #region Executes
        public virtual void OnGameUpdate() { }
        public virtual void OnGameFixedUpdate() { }
        public virtual void Reload() { }
        #endregion
    }
}
