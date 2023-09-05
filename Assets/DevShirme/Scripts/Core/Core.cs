using DevShirme.Utils;
using DevShirme.DesignPatterns.Creationals;
using DevShirme.Interfaces;
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
        private ILoader loader;
        private List<ILoadable> managers;
        #endregion

        #region Getters
        public Manager GetManager(Enums.ManagerType managerType)
        {
            Manager manager = (Manager)managers[Utilities.FlagsValueToIndex(((int)managerType))];
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

            loader = new Loader();
            managers = loader.LoadManagers(coreSettings.Managers, coreSettings.ManagersSettings);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion

        #region Updates
        private void Update()
        {
            for (int i = 0; i < managers.Count; i++)
                managers[i].ExternalUpdate();
        }
        private void FixedUpdate()
        {
            for (int i = 0; i < managers.Count; i++)
                managers[i].ExternalFixedUpdate();
        }
        #endregion
    }
}
