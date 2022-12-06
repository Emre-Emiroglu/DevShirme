using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class DevShirmeManager : MonoBehaviour
    {
        protected Utils.Enums.ManagerType managerType;
        public abstract void Initialize();
    }
}
