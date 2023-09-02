using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface ILoadable
    {
        public abstract void ExternalUpdate();
        public abstract void ExternalFixedUpdate();
    }
}
