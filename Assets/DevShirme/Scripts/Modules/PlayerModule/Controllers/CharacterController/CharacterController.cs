using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class CharacterController : Controller
    {
        #region Fields
        private readonly CharacterControllerSettings ccSettings;
        private readonly IPlayerAgent playerAgent;
        #endregion

        #region Props
        public Vector2 MovementInput { get; set; }
        public Vector2 RotationInput { get; set; }
        public Enums.KeyCodeState KeyCodeState { get; set; }
        #endregion

        #region Core
        public CharacterController(ScriptableObject _settings) : base(_settings)
        {
            ccSettings = _settings as CharacterControllerSettings;

            playerAgent = Object.FindObjectOfType<PlayerAgent>();
            playerAgent?.Initialize(ccSettings);
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            if (ccSettings.MovementData.MovementType == Enums.MovementType.Transform)
                playerAgent?.Movement(MovementInput, KeyCodeState);

            playerAgent?.Rotation(RotationInput, KeyCodeState);
        }
        public override void ExternalFixedUpdate()
        {
            if (ccSettings.MovementData.MovementType == Enums.MovementType.Rigidbody)
                playerAgent?.Movement(MovementInput, KeyCodeState);
        }
        #endregion
    }
}
