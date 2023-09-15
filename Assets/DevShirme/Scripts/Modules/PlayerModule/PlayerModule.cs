using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.Modules.PlayerModule
{
    public class PlayerModule: Module
    {
        #region Fields
        private readonly PlayerSettings playerSettings;
        private readonly PCInputController pcInputController;
        private readonly MobileInputController mobileInputController;
        private readonly DevCharacterController characterController;
        private readonly Controller[] controllers;
        #endregion

        #region Core
        public PlayerModule(PlayerSettings playerSettings, PCInputController pcInputController, MobileInputController mobileInputController, DevCharacterController characterController) : base()
        {
            this.playerSettings = playerSettings;
            this.pcInputController = pcInputController;
            this.mobileInputController = mobileInputController;
            this.characterController = characterController;

            controllers = new Controller[2];
            controllers[((int)Enums.PlayerModuleControllerType.InputController)] = this.pcInputController;
            controllers[((int)Enums.PlayerModuleControllerType.CharacterController)] = this.characterController;
        }
        #endregion

        #region Updates
        public override void Tick()
        {
            characterController.MovementInput = pcInputController.MovementInput;
            characterController.RotationInput = pcInputController.RotationInput;
            characterController.LeftClick = pcInputController.LeftClick;
            characterController.KeyCodeState = pcInputController.KeyCodeState;

            for (int i = 0; i < controllers.Length; i++)
                controllers[i].Tick();
        }
        public override void FixedTick()
        {
            for (int i = 0; i < controllers.Length; i++)
                controllers[i].FixedTick();
        }
        public override void LateTick()
        {
            for (int i = 0; i < controllers.Length; i++)
                controllers[i].LateTick();
        }
        #endregion
    }
}
