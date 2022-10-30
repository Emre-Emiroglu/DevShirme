using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Core
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        [Header("Singleton Settings")]
        [SerializeField] private Utils.Enums.DestroyType destroyType;

        #region Getters
        public static T Instance { get; private set; }
        #endregion

        #region Singleton
        public virtual void Initialize()
        {
            InitProcess();
        }
        protected virtual void OnDestroy()
        {
            switch (destroyType)
            {
                case Utils.Enums.DestroyType.DestroyNewObj:
                    if (Instance != null)
                        Destroy(FindObjectOfType<T>());
                    break;
                case Utils.Enums.DestroyType.DestroyOldObj:
                    Destroy(gameObject);
                    break;
            }
        }
        private void InitProcess()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this);
            }
        }
        #endregion

    }
}
