using DevShirme.Modules.PlayerModule;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IPlayerAgent
    {
        public void Initialize(CharacterControllerSettings playerSettings);
        public void Movement(Vector2 input, Enums.KeyCodeState keyCodeState);
        public void Rotation(Vector2 input, Enums.KeyCodeState keyCodeState);
    }
}
