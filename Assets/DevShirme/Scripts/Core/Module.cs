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
        public virtual void Initialize()
        {
            setSubs(true);
        }
        protected virtual void setSubs(bool isSub)
        {
            if (isSub)
            {
            }
            else
            {
            }
        }
        private void OnDestroy()
        {
            setSubs(false);
        }
        #endregion
    }
}
