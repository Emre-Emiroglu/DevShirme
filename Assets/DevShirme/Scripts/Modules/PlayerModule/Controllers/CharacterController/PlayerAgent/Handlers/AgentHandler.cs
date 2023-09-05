using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public abstract class AgentHandler : IAgentHandler
    {
        #region Core
        public abstract void ExternalUpdate(Vector2 input);
        public abstract void ExternalFixedUpdate(Vector2 input);
        #endregion
    }
}
