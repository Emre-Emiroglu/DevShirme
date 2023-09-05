using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IAgentHandler
    {
        public void ExternalUpdate(Vector2 input);
        public void ExternalFixedUpdate(Vector2 input);
    }
}
