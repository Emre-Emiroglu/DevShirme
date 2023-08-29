using DevShirme.Interfaces;
using DevShirme.Utils;
using DevShirme.Managers.DataManager;
using DevShirme.Managers.GameManager;
using DevShirme.Managers.PoolManager;
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
        private Dictionary<int, IManager> managers;
        private List<IManager> loadedManagers;    
        #endregion

        #region Getters
        public IManager GetManager(Enums.ManagerType managerType)
        {
            IManager manager = managers[Utilities.FlagsValueToIndex(((int)managerType))];
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

            createManagers();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion

        #region Creates
        private void createManagers()
        {
            managers = new Dictionary<int, IManager>();
            loadedManagers = new List<IManager>();

            bool hasDM = coreSettings.Managers.HasFlag(Enums.ManagerType.DataManager);
            bool hasPM = coreSettings.Managers.HasFlag(Enums.ManagerType.PoolManager);
            bool hasGM = coreSettings.Managers.HasFlag(Enums.ManagerType.GameManager);

            if (hasDM)
                createManager(Enums.ManagerType.DataManager);
            if (hasPM)
                createManager(Enums.ManagerType.PoolManager);
            if (hasGM)
                createManager(Enums.ManagerType.GameManager);
        }
        private void createManager(Enums.ManagerType managerType)
        {
            int indexValue = Utilities.FlagsValueToIndex(((int)managerType));
            bool contain = managers.ContainsKey(indexValue);
            IManager manager = null;
            if (!contain)
            {
                ScriptableObject settings = coreSettings.ManagersSettings[indexValue];
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
                managers.Add(indexValue, manager);
                loadedManagers.Add(manager);
            }
        }
        #endregion

        #region Updates
        private void Update()
        {
            for (int i = 0; i < loadedManagers.Count; i++)
                loadedManagers[i].ExternalUpdate();
        }
        private void FixedUpdate()
        {
            for (int i = 0; i < loadedManagers.Count; i++)
                loadedManagers[i].ExternalFixedUpdate();
        }
        #endregion
    }
}
