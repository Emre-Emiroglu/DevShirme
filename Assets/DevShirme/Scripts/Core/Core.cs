using DevShirme.Interfaces;
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
        private Dictionary<int, IManager> managers;
        #endregion

        #region Getters
        public IManager GetManager(Enums.ManagerType managerType)
        {
            IManager manager = managers[getIndexValue(((int)managerType))];
            if (manager == null)
            {
                Debug.LogError("You dont have: " + managerType.ToString());
                return null;
            }
            else
                return manager;
        }
        private ScriptableObject getSettings(int indexValue)
        {
            ScriptableObject settings = coreSettings.ManagersSettings[indexValue];
            return settings;
        }
        private int getIndexValue(int baseValue)
        {
            return baseValue == 1 ? 0 : baseValue / 2;
        }
        private bool checkIsCreated(int keyValue)
        {
            return managers.ContainsKey(keyValue);
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

            bool hasDM = coreSettings.Managers.HasFlag(Enums.ManagerType.DataManager);
            bool hasPM = coreSettings.Managers.HasFlag(Enums.ManagerType.PoolManager);
            bool hasGM = coreSettings.Managers.HasFlag(Enums.ManagerType.GameManager);

            if (hasDM)
            {
                int indexValue = getIndexValue(((int)Enums.ManagerType.DataManager));
                if (!checkIsCreated(indexValue))
                {
                    ScriptableObject settings = getSettings(indexValue);
                    IManager manager = new DataManager(settings);
                    managers.Add(indexValue, manager);
                }
            }
            if (hasPM)
            {
                int indexValue = getIndexValue(((int)Enums.ManagerType.PoolManager));
                if (!checkIsCreated(indexValue))
                {
                    ScriptableObject settings = getSettings(indexValue);
                    IManager manager = new PoolManager(settings);
                    managers.Add(indexValue, manager);
                }
            }
            if (hasGM)
            {
                int indexValue = getIndexValue(((int)Enums.ManagerType.GameManager));
                if (!checkIsCreated(indexValue))
                {
                    ScriptableObject settings = getSettings(indexValue);
                    IManager manager = new GameManager(settings);
                    managers.Add(indexValue, manager);
                }
            }
        }
        #endregion
    }
}
