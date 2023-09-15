using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class DevCharacterController : Controller
    {
        #region Fields
        private readonly CharacterControllerSettings ccSettings;
        private readonly PlayerAgent playerAgent;
        #endregion

        #region Props
        public Vector2 MovementInput { get; set; }
        public Vector2 RotationInput { get; set; }
        public Enums.KeyCodeState KeyCodeState { get; set; }
        #endregion

        #region Core
        public DevCharacterController(CharacterControllerSettings ccSettings, PlayerAgent playerAgent) : base()
        {
            this.ccSettings = ccSettings;
            this.playerAgent = playerAgent;

            this.playerAgent?.Initialize(this.ccSettings);
        }
        #endregion

        #region Updates
        public override void Tick()
        {
            if (ccSettings.MovementData.MovementType == Enums.MovementType.Transform)
                playerAgent?.Movement(MovementInput, KeyCodeState);

            playerAgent?.Rotation(RotationInput, KeyCodeState);
        }
        public override void FixedTick()
        {
            if (ccSettings.MovementData.MovementType == Enums.MovementType.Rigidbody)
                playerAgent?.Movement(MovementInput, KeyCodeState);
        }
        public override void LateTick()
        {
        }
        #endregion
    }
}
