using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevShirme
{
    public abstract class DevShirmeController : MonoBehaviour
    {
        #region Fields
        [SerializeField] protected DevSettings settings;
        #endregion

        #region Getters
        public DevSettings Settings => settings;
        #endregion

        #region Core
        public abstract void Initialize();
        #endregion
    }
}
