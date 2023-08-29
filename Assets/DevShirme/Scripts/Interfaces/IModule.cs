using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IModule
    {
        public void SetSubscriptions(bool isSub);
        public void ExternalUpdate();
        public void ExternalFixedUpdate();
    }
}
