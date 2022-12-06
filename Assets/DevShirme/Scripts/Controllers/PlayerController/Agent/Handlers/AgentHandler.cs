using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public abstract class AgentHandler
    {
        #region Fields
        protected readonly PlayerSettings settings;
        protected readonly Transform _obj;
        #endregion

        #region Core
        public AgentHandler(PlayerSettings settings, Transform obj)
        {
            this.settings = settings;
            _obj = obj;
        }
        #endregion

        #region Execute
        public abstract void Execute(Vector2 input);

        #endregion
    }
}
