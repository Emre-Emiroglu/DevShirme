using DevShirme.Interfaces;
using DevShirme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public abstract class InputController: Controller
    {
        #region Fields
        protected readonly InputControllerSettings _icSettings;
        protected Vector2 _movementInput;
        protected Vector2 _rotationInput;
        protected Enums.KeyCodeState _keyCodeState;
        #endregion

        #region Getters
        public Vector2 MovementInput => _movementInput;
        public Vector2 RotationInput => _rotationInput;
        public Enums.KeyCodeState KeyCodeState => _keyCodeState;
        #endregion

        #region Core
        public InputController(ScriptableObject _settings) : base(_settings)
        {
            _icSettings = _settings as InputControllerSettings;
        }
        public abstract void ClearInputs();
        protected abstract void inputUpdate();
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
        }
        public override void ExternalFixedUpdate()
        {
        }
        #endregion
    }
}
