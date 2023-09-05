using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class PlayerAgent : MonoBehaviour, IPlayerAgent
    {
        #region Fields
        [Header("Components")]
        private Rigidbody rb;
        private CharacterControllerSettings ccSettings;
        [Header("Handlers")]
        private IAgentHandler movementHandler;
        private IAgentHandler rotationHandler;
        #endregion

        #region Core
        public void Initialize(CharacterControllerSettings ccSettings)
        {
            rb = GetComponent<Rigidbody>();

            this.ccSettings = ccSettings;

            movementHandler = new MovementHandler(ccSettings.MovementData);
            rotationHandler = new RotationHandler(ccSettings.RotationData);
        }
        #endregion

        #region Updates
        public void ExternalUpdate(Vector2 input)
        {
            movementHandler.ExternalUpdate(input);
            rotationHandler.ExternalUpdate(input);
        }
        public void ExternalFixedUpdate(Vector2 input)
        {
            movementHandler.ExternalFixedUpdate(input);
        }
        #endregion
    }
}
