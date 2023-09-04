using DevShirme.Utils;
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

            loader = new ManagerLoader(coreSettings.Managers, coreSettings.ManagersSettings);
            loader.Load();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
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
