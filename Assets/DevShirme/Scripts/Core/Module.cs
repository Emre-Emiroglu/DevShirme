using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Module: MonoBehaviour
    {
        #region Fields
        [Header("Module Components")]
        [SerializeField] protected ScriptableObject settings;
        #endregion

        #region Core
        public abstract void Initialize();
        #endregion
    }
}
