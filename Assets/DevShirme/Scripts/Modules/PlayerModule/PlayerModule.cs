using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class PlayerModule: Module
    {
        #region Fields
        private readonly PlayerSettings playerSettings;
        private readonly ILoadable inputController;
        private readonly ILoadable characterController;
        private readonly ILoadable[] controllers;
        #endregion

        #region Core
        public PlayerModule(ScriptableObject _settings) : base(_settings)
        {
            playerSettings = _settings as PlayerSettings;

            InputControllerSettings icSettings = playerSettings.ControllersSettings[((int)Enums.PlayerModuleControllerType.InputController)] as InputControllerSettings;
            switch (icSettings.InputType)
            {
                case Enums.InputType.Mobile:
                    inputController = new MobileInputController(icSettings);
                    break;
                case Enums.InputType.PC:
                    inputController = new PCInputController(icSettings);
                    break;
            }

            characterController = new CharacterController((InputController)inputController, playerSettings.ControllersSettings[((int)Enums.PlayerModuleControllerType.CharacterController)]);

            controllers = new ILoadable[2];
            controllers[0] = inputController;
            controllers[1] = characterController;
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            for (int i = 0; i < controllers.Length; i++)
                controllers[i].ExternalUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            for (int i = 0; i < controllers.Length; i++)
                controllers[i].ExternalFixedUpdate();
        }
        #endregion

        #region Subscriptions
        public override void SetSubscriptions(bool isSub)
        {
        }
        #endregion
    }
}
