using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IUpdateable
    {
        public void ExternalUpdate();
        public void ExternalFixedUpdate();
    }
}
