using DevShirme.DesignPatterns.Creationals;
using DevShirme.Managers.DataManager;
using DevShirme.Managers.PoolManager;
using DevShirme.Managers.GameManager;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Modules.ADModule;
using DevShirme.Modules.PlayerModule;
using DevShirme.Modules.CameraModule;
using DevShirme.Modules.UIModule;

namespace DevShirme
{
    public class Core : MonoSingleton<Core>
    {
        #region Fields
        [Header("Core Fields")]
        [SerializeField] private CoreSettings coreSettings;
        private DataManager dataManager;
        private PoolManager poolManager;
        private GameManager gameManager;
        private Manager[] managers;
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

            installs();

            managers = new Manager[3];
            managers[((int)Enums.ManagerType.DataManager)] = dataManager;
            managers[((int)Enums.ManagerType.PoolManager)] = poolManager;
            managers[((int)Enums.ManagerType.GameManager)] = gameManager;
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        #endregion

        #region Installs
        private void installs()
        {
            DataManagerSettings dmSettings = coreSettings.ManagersSettings[((int)Enums.ManagerType.DataManager)] as DataManagerSettings;
            PoolManagerSettings pmSettings = coreSettings.ManagersSettings[((int)Enums.ManagerType.PoolManager)] as PoolManagerSettings;
            GameManagerSettings gmSettings = coreSettings.ManagersSettings[((int)Enums.ManagerType.GameManager)] as GameManagerSettings;

            ADSettings adSettings = gmSettings.ModulesSettings[((int)Enums.ModuleType.ADModule)] as ADSettings;
            PlayerSettings playerSettings = gmSettings.ModulesSettings[((int)Enums.ModuleType.PlayerModule)] as PlayerSettings;
            CameraSettings cameraSettings = gmSettings.ModulesSettings[((int)Enums.ModuleType.CameraModule)] as CameraSettings;
            UISettings uiSettings = gmSettings.ModulesSettings[((int)Enums.ModuleType.UIModule)] as UISettings;

            InputControllerSettings icSettings = playerSettings.ControllersSettings[((int)Enums.PlayerModuleControllerType.InputController)] as InputControllerSettings;
            CharacterControllerSettings ccSettings = playerSettings.ControllersSettings[((int)Enums.PlayerModuleControllerType.CharacterController)] as CharacterControllerSettings;

            PlayerAgent playerAgent = FindObjectOfType<PlayerAgent>();
            Cam[] cams = FindObjectsOfType<Cam>();
            UIPanel[] panels = FindObjectsOfType<UIPanel>();

            dataManager = new DataManager(dmSettings);
            poolManager = new PoolManager(pmSettings, transform.GetChild(0));
            gameManager = new GameManager(gmSettings, new ADModule(adSettings),
                new PlayerModule(playerSettings, new PCInputController(icSettings), new MobileInputController(icSettings), new DevCharacterController(ccSettings, playerAgent)),
                new CameraModule(cameraSettings, cams),
                new UIModule(uiSettings, panels));
        }
        #endregion

        #region Updates
        private void Update()
        {
            for (int i = 0; i < managers.Length; i++)
                managers[i].Tick();
        }
        private void FixedUpdate()
        {
            for (int i = 0; i < managers.Length; i++)
                managers[i].FixedTick();
        }
        private void LateUpdate()
        {
            for (int i = 0; i < managers.Length; i++)
                managers[i].LateTick();
        }
        #endregion
    }
}
