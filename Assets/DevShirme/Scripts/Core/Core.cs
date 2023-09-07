using DevShirme.Interfaces;
using DevShirme.DesignPatterns.Creationals;
using DevShirme.Managers.DataManager;
using DevShirme.Managers.PoolManager;
using DevShirme.Managers.GameManager;
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
        [SerializeField] private CoreSettings coreSettings;
        private ILoadable dataManager;
        private ILoadable poolManager;
        private ILoadable gameManager;
        private ILoadable[] managers;
        #endregion

        #region Getters
        public Manager GetManager(Enums.ManagerType managerType)
        {
            Manager manager = (Manager)managers[((int)managerType)];
            if (manager == null)
            {
                Debug.LogError("You dont have: " + managerType.ToString());
                return null;
            }
            else
                return manager;
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

            dataManager = new DataManager(coreSettings.ManagersSettings[((int)Enums.ManagerType.DataManager)]);
            poolManager = new PoolManager(coreSettings.ManagersSettings[((int)Enums.ManagerType.PoolManager)]);
            gameManager = new GameManager(coreSettings.ManagersSettings[((int)Enums.ManagerType.GameManager)]);

            managers = new ILoadable[]
            {
                managers[0] = dataManager,
                managers[1] = poolManager,
                managers[2] = gameManager
            };
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion

        #region Updates
        private void Update()
        {
            for (int i = 0; i < managers.Length; i++)
                managers[i].ExternalUpdate();
        }
        private void FixedUpdate()
        {
            for (int i = 0; i < managers.Length; i++)
                managers[i].ExternalFixedUpdate();
        }
        #endregion
    }
}
