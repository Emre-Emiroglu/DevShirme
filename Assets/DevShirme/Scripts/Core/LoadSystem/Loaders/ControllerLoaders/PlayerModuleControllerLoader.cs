using DevShirme.Modules.PlayerModule;
using DevShirme.Modules.PlayerModule.Controllers;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class PlayerModuleControllerLoader : Loader
    {
        #region Fields
        private readonly Enums.PlayerModuleControllerType playerModuleControllerType;
        #endregion

        #region Core
        public PlayerModuleControllerLoader(Enums.PlayerModuleControllerType playerModuleControllerType, ScriptableObject[] scriptableObjects) : base(scriptableObjects)
        {
            this.playerModuleControllerType = playerModuleControllerType;
        }
        public override void Load()
        {
            bool hasIC = playerModuleControllerType.HasFlag(Enums.PlayerModuleControllerType.InputController);
            bool hasCC = playerModuleControllerType.HasFlag(Enums.PlayerModuleControllerType.CharacterController);

            if (hasIC)
                create(Enums.PlayerModuleControllerType.InputController);
            if (hasCC)
                create(Enums.PlayerModuleControllerType.CharacterController);
        }
        private void create(Enums.PlayerModuleControllerType playerModuleControllerType)
        {
            int indexValue = Utilities.FlagsValueToIndex(((int)playerModuleControllerType));
            ScriptableObject settings = _scriptableObjects[indexValue];
            if (!isContain(indexValue))
            {
                Controller controller = null;
                switch (playerModuleControllerType)
                {
                    case Enums.PlayerModuleControllerType.InputController:
                        InputControllerSettings icSettings = settings as InputControllerSettings;
                        switch (icSettings.InputType)
                        {
                            case Enums.InputType.Mobile:
                                controller = new MobileInputController(icSettings);
                                break;
                            case Enums.InputType.PC:
                                controller = new PCInputController(icSettings);
                                break;
                        }
                        break;
                    case Enums.PlayerModuleControllerType.CharacterController:
                        controller = new DevCharacterController(settings);
                        break;
                }
                _loadables.Add(indexValue, controller);
                _loadeds.Add(controller);
            }
        }
        #endregion
    }
}
