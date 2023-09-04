using DevShirme.Utils;
using DevShirme.Managers.DataManager;
using DevShirme.Managers.GameManager;
using DevShirme.Managers.PoolManager;
using DevShirme.DesignPatterns.Creationals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Interfaces;

namespace DevShirme
{
    public class Core : MonoSingleton<Core>
    {
        #region Fields
        [Header("Core Fields")]
        [SerializeField] private CoreSettings coreSettings;
        private ILoader loader;
        #endregion

        #region Getters
        public Manager GetManager(Enums.ManagerType managerType)
        {
            Manager manager = (Manager)loader.Loadeds[Utilities.FlagsValueToIndex(((int)managerType))];
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

            loads();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion

        #region Loads
        private void loads()
        {
            loader = new Loader();

            bool hasDM = coreSettings.Managers.HasFlag(Enums.ManagerType.DataManager);
            bool hasPM = coreSettings.Managers.HasFlag(Enums.ManagerType.PoolManager);
            bool hasGM = coreSettings.Managers.HasFlag(Enums.ManagerType.GameManager);

            if (hasDM)
                singleLoad(Enums.ManagerType.DataManager);
            if (hasPM)
                singleLoad(Enums.ManagerType.PoolManager);
            if (hasGM)
                singleLoad(Enums.ManagerType.GameManager);
        }
        private void singleLoad(Enums.ManagerType managerType)
        {
            int indexValue = Utilities.FlagsValueToIndex(((int)managerType));
            ScriptableObject settings = coreSettings.ManagersSettings[indexValue];
            if (!loader.IsContain(indexValue))
            {
                Manager manager = null;
                switch (managerType)
                {
                    case Enums.ManagerType.DataManager:
                        manager = new DataManager(settings);
                        break;
                    case Enums.ManagerType.PoolManager:
                        manager = new PoolManager(settings);
                        break;
                    case Enums.ManagerType.GameManager:
                        manager = new GameManager(settings);
                        break;
                }
                loader.AddLoadable(indexValue, manager);
            }
        }
        #endregion

        #region Updates
        private void Update()
        {
            for (int i = 0; i < loader.Loadeds.Count; i++)
                loader.Loadeds[i].ExternalUpdate();
        }
        private void FixedUpdate()
        {
            for (int i = 0; i < loader.Loadeds.Count; i++)
                loader.Loadeds[i].ExternalFixedUpdate();
        }
        #endregion
    }
}
