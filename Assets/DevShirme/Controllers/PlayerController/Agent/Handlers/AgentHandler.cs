using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public abstract class AgentHandler : MonoBehaviour
    {
        protected PlayerSettings settings;
        public virtual void Initialize(PlayerSettings settings){ this.settings = settings; }
        public abstract void Execute(Vector2 input);
    }
}
