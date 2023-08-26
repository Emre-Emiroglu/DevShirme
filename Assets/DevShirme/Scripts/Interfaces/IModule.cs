using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IModule
    {
        public void Initialize();
        public void Shutdown();
    }
}
