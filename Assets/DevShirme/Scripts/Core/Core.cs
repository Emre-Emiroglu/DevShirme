using DevShirme.Interfaces;
using DevShirme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class Core : MonoSingleton<Core>
    {
        #region Fields
        [Header("Core Settings")]
        [SerializeField] private ManagerService[] managerServices;
        private Dictionary<int, IManager> managers;
        #endregion

        #region Getters
        public IManager GetManager(Enums.ManagerType managerType)
        {
            IManager manager = managers[((int)managerType)];
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

        #region Executes
        private void createManagers()
        {
            managers = new Dictionary<int, IManager>();

            for (int i = 0; i < managerServices.Length; i++)
            {
                ManagerService service = managerServices[i];

                if (!managers.ContainsKey(((int)service.ManagerType)))
                {
                    IManager manager = service.CreateManager();
                    managers.Add(((int)service.ManagerType), manager);
                }
                else
                {
                    Debug.LogWarning("You already select a: " + service.ManagerType.ToString());
                }
            }
        }
        #endregion
    }

    [Serializable]
    public class ManagerService
    {
        #region Fields
        [SerializeField] private Enums.ManagerType managerType;
        [SerializeField] private ScriptableObject managerSettings;
        [SerializeField] private Transform transform;
        #endregion

        #region Getters
        public Enums.ManagerType ManagerType => managerType;
        #endregion

        #region Executes
        public IManager CreateManager()
        {
            IManager manager = null;

            switch (managerType)
            {
                case Enums.ManagerType.DataManager:
                    manager = new DataManager(managerSettings);
                    break;
                case Enums.ManagerType.PoolManager:
                    manager = new PoolManager(managerSettings, transform);
                    break;
                case Enums.ManagerType.GameManager:
                    manager = new GameManager(managerSettings);
                    break;
            }

            return manager;
        }
        #endregion
    }
}
