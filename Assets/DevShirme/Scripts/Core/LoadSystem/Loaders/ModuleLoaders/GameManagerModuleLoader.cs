using DevShirme.Modules.ADModule;
using DevShirme.Modules.CameraModule;
using DevShirme.Modules.PlayerModule;
using DevShirme.Modules.UIModule;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class GameManagerModuleLoader : Loader
    {
        #region Fields
        private readonly Enums.GameManagerModuleType gameManagerModuleType;
        #endregion

        #region Core
        public GameManagerModuleLoader(Enums.GameManagerModuleType gameManagerModuleType, ScriptableObject[] scriptableObjects) : base(scriptableObjects)
        {
            this.gameManagerModuleType = gameManagerModuleType;
        }
        public override void Load()
        {
            bool hasAD = gameManagerModuleType.HasFlag(Enums.GameManagerModuleType.ADModule);
            bool hasPM = gameManagerModuleType.HasFlag(Enums.GameManagerModuleType.PlayerModule);
            bool hasCM = gameManagerModuleType.HasFlag(Enums.GameManagerModuleType.CameraModule);
            bool hasUM = gameManagerModuleType.HasFlag(Enums.GameManagerModuleType.UIModule);

            if (hasAD)
                create(Enums.GameManagerModuleType.ADModule);
            if (hasPM)
                create(Enums.GameManagerModuleType.PlayerModule);
            if (hasCM)
                create(Enums.GameManagerModuleType.CameraModule);
            if (hasUM)
                create(Enums.GameManagerModuleType.UIModule);
        }
        private void create(Enums.GameManagerModuleType gameManagerModuleType)
        {
            int indexValue = Utilities.FlagsValueToIndex(((int)gameManagerModuleType));
            ScriptableObject settings = _scriptableObjects[indexValue];
            if (!isContain(indexValue))
            {
                Module module = null;
                switch (gameManagerModuleType)
                {
                    case Enums.GameManagerModuleType.ADModule:
                        module = new ADModule(settings);
                        break;
                    case Enums.GameManagerModuleType.PlayerModule:
                        module = new PlayerModule(settings);
                        break;
                    case Enums.GameManagerModuleType.CameraModule:
                        module = new CameraModule(settings);
                        break;
                    case Enums.GameManagerModuleType.UIModule:
                        module = new UIModule(settings);
                        break;
                }
                _loadables.Add(indexValue, module);
                _loadeds.Add(module);
            }
        }
        #endregion
    }
}
