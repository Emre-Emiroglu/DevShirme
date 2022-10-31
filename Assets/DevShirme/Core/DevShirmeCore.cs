using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Core
{
    public class DevShirmeCore : MonoSingleton<DevShirmeCore>
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private List<DevShirmeManager> managers;
        #endregion

        #region Getters
        public DevShirmeManager GetAManager(Utils.Enums.ManagerType type)
        {
            return managers[((int)type)];
        }
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();
            for (int i = 0; i < managers.Count; i++)
            {
                managers[i].Initialize();
            }
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        private void Awake()
        {
            Initialize();
        }
        #endregion

    }
}
