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
        [SerializeField] private List<ManagerContainer> managerContainers;
        #endregion

        #region Getters
        public Manager GetManager(Enums.InitType initType, Enums.ManagerType managerType)
        {
            return managerContainers[((int)initType)].Managers[((int)managerType)];
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
            preInitialize();
            initialize();
            afterýnitialize();
        }
        private void preInitialize()
        {
            for (int i = 0; i < managerContainers[((int)Enums.InitType.PreInit)].Managers.Count; i++)
            {
                managerContainers[((int)Enums.InitType.PreInit)].Managers[i].Initialize();
            }
        }
        private void initialize()
        {
            for (int i = 0; i < managerContainers[((int)Enums.InitType.Init)].Managers.Count; i++)
            {
                managerContainers[((int)Enums.InitType.Init)].Managers[i].Initialize();
            }
        }
        private void afterýnitialize()
        {
            for (int i = 0; i < managerContainers[((int)Enums.InitType.Afterýnit)].Managers.Count; i++)
            {
                managerContainers[((int)Enums.InitType.Afterýnit)].Managers[i].Initialize();
            }
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion
    }
    [System.Serializable]
    public class ManagerContainer
    {
        [SerializeField] private Enums.InitType initType;
        [SerializeField] private List<Manager> managers;

        public List<Manager> Managers => managers;
    }
}
