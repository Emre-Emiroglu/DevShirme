using DevShirme.Utils;
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
        protected bool _leftClick;
        protected Enums.MovementState _keyCodeState;
        #endregion

        #region Getters
        public Vector2 MovementInput => _movementInput;
        public Vector2 RotationInput => _rotationInput;
        public bool LeftClick => _leftClick;
        public Enums.MovementState KeyCodeState => _keyCodeState;
        #endregion

        #region Core
        public InputController(InputControllerSettings _icSettings) : base()
        {
            this._icSettings = _icSettings;
        }
        public abstract void ClearInputs();
        protected abstract void inputUpdate();
        #endregion

        #region Updates
        public override void Tick()
        {
        }
        public override void FixedTick()
        {
        }
        public override void LateTick()
        {
        }
        #endregion
    }
}
