using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class Module: MonoBehaviour, IModule
    {
        #region Fields
        [Header("Module Components")]
        [SerializeField] protected ScriptableObject settings;
        #endregion

        #region Core
        public virtual void Initialize()
        {
            setSubscriptions(true);
        }
        public virtual void Shutdown()
        {
            setSubscriptions(false);
        }
        protected virtual void setSubscriptions(bool isSub)
        {
            if (isSub)
            {
            }
            else
            {
            }
        }
        #endregion
    }
}
