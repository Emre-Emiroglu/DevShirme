using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface ILoader
    {
        public List<ILoadable> LoadManagers(Enums.ManagerType managerType, ScriptableObject[] settingsArray);
        public List<ILoadable> LoadModules(Enums.ModuleType moduleType, ScriptableObject[] settingsArray);
        public List<ILoadable> LoadPlayerModuleControllers(Enums.PlayerModuleControllerType playerModuleControllerType, ScriptableObject[] settingsArray);
    }
}
