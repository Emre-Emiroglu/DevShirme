using DevShirme.Modules.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IPlayerAgent
    {
        public bool IsActived { get; set; }
        public void Initialize(PlayerSettings playerSettings);
    }
}
