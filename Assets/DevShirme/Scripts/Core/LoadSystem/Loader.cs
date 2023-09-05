using DevShirme.Interfaces;
using DevShirme.Managers.DataManager;
using DevShirme.Managers.GameManager;
using DevShirme.Managers.PoolManager;
using DevShirme.Modules.ADModule;
using DevShirme.Modules.CameraModule;
using DevShirme.Modules.PlayerModule;
using DevShirme.Modules.PlayerModule.Controllers;
using DevShirme.Modules.UIModule;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class Loader: ILoader
    {
        #region Managers
        public List<ILoadable> LoadManagers(Enums.ManagerType managerType, ScriptableObject[] settingsArray)
        {
            List<ILoadable> list = new List<ILoadable>();

            bool hasDM = managerType.HasFlag(Enums.ManagerType.DataManager);
            bool hasPM = managerType.HasFlag(Enums.ManagerType.PoolManager);
            bool hasGM = managerType.HasFlag(Enums.ManagerType.GameManager);

            if (hasDM)
                list.Add(createManager(Enums.ManagerType.DataManager, settingsArray));
            if (hasPM)
                list.Add(createManager(Enums.ManagerType.PoolManager, settingsArray));
            if (hasGM)
                list.Add(createManager(Enums.ManagerType.GameManager, settingsArray));

            return list;
        }
        private ILoadable createManager(Enums.ManagerType managerType, ScriptableObject[] settingsArray)
        {
            Manager m = null;
            ScriptableObject settings = settingsArray[Utilities.FlagsValueToIndex(((int)managerType))];

            switch (managerType)
            {
                case Enums.ManagerType.DataManager:
                    m = new DataManager(settings);
                    break;
                case Enums.ManagerType.PoolManager:
                    m = new PoolManager(settings);
                    break;
                case Enums.ManagerType.GameManager:
                    m = new GameManager(settings);
                    break;
            }

            return m;
        }
        #endregion

        #region Modules
        public List<ILoadable> LoadModules(Enums.ModuleType moduleType, ScriptableObject[] settingsArray)
        {
            List<ILoadable> list = new List<ILoadable>();

            bool hasAD = moduleType.HasFlag(Enums.ModuleType.ADModule);
            bool hasPM = moduleType.HasFlag(Enums.ModuleType.PlayerModule);
            bool hasCM = moduleType.HasFlag(Enums.ModuleType.CameraModule);
            bool hasUM = moduleType.HasFlag(Enums.ModuleType.UIModule);

            if (hasAD)
                createModule(Enums.ModuleType.ADModule, settingsArray);
            if (hasPM)
                createModule(Enums.ModuleType.PlayerModule, settingsArray);
            if (hasCM)
                createModule(Enums.ModuleType.CameraModule, settingsArray);
            if (hasUM)
                createModule(Enums.ModuleType.UIModule, settingsArray);

            return list;
        }
        private ILoadable createModule(Enums.ModuleType moduleType, ScriptableObject[] settingsArray)
        {
            Module m = null;
            ScriptableObject settings = settingsArray[Utilities.FlagsValueToIndex(((int)moduleType))];

            switch (moduleType)
            {
                case Enums.ModuleType.ADModule:
                    m = new ADModule(settings);
                    break;
                case Enums.ModuleType.PlayerModule:
                    m = new PlayerModule(settings);
                    break;
                case Enums.ModuleType.CameraModule:
                    m = new CameraModule(settings);
                    break;
                case Enums.ModuleType.UIModule:
                    m = new UIModule(settings);
                    break;
            }
            return m;
        }
        #endregion

        #region PlayerModuleControllers
        public List<ILoadable> LoadPlayerModuleControllers(Enums.PlayerModuleControllerType playerModuleControllerType, ScriptableObject[] settingsArray)
        {
            List<ILoadable> list = new List<ILoadable>();

            bool hasIC = playerModuleControllerType.HasFlag(Enums.PlayerModuleControllerType.InputController);
            bool hasCC = playerModuleControllerType.HasFlag(Enums.PlayerModuleControllerType.CharacterController);

            if (hasIC)
                createModule(Enums.ModuleType.ADModule, settingsArray);
            if (hasCC)
                createModule(Enums.ModuleType.PlayerModule, settingsArray);

            return list;
        }
        private ILoadable createPlayerModuleController(Enums.PlayerModuleControllerType playerModuleControllerType, ScriptableObject[] settingsArray)
        {
            Controller c = null;
            ScriptableObject settings = settingsArray[Utilities.FlagsValueToIndex(((int)playerModuleControllerType))];

            switch (playerModuleControllerType)
            {
                case Enums.PlayerModuleControllerType.InputController:
                    InputControllerSettings icSettings = settings as InputControllerSettings;
                    switch (icSettings.InputType)
                    {
                        case Enums.InputType.Mobile:
                            c = new MobileInputController(icSettings);
                            break;
                        case Enums.InputType.PC:
                            c = new PCInputController(icSettings);
                            break;
                    }
                    break;
                case Enums.PlayerModuleControllerType.CharacterController:
                    c = new DevCharacterController(settings);
                    break;
            }
            return c;
        }
        #endregion
    }
}
