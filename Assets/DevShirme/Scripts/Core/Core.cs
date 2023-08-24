using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class Core : MonoSingleton<Core>
    {
        #region Fields
        [Header("Core Fields")]
        [SerializeField] private Manager[] managers;
        #endregion

        #region Getters
        public Manager GetManager(Enums.ManagerType managerType)
        {
            return managers[((int)managerType)];
        }
        #endregion

        #region Core
        private void Awake()
        {
            Initialize();
        }
        public override void Initialize()
        {
            base.Initialize();

            for (int i = 0; i < managers.Length; i++)
            {
                managers[i].Initialize();
            }
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion
    }
}
