using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IAgentHandler
    {
        public void Execute(Vector2 input, Enums.KeyCodeState keyCodeState);
    }
}
