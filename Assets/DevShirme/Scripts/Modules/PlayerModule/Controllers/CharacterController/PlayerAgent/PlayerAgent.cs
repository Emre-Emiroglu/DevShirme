using DevShirme.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerAgent : MonoBehaviour, IPlayerAgent
    {
        #region Fields
        [Header("Components")]
        private Rigidbody rb;
        [Header("Handlers")]
        private IAgentHandler movementHandler;
        private IAgentHandler rotationHandler;
        #endregion

        #region Core
        public void Initialize(ISubject subject, CharacterControllerSettings ccSettings)
        {
            rb = GetComponent<Rigidbody>();

            movementHandler = new MovementHandler(ccSettings.MovementData, subject, transform, rb);
            rotationHandler = new RotationHandler(ccSettings.RotationData, subject, transform, rb);
        }
        #endregion

        #region Updates
        public void ExternalUpdate()
        {
            movementHandler.ExternalUpdate();
            rotationHandler.ExternalUpdate();
        }
        public void ExternalFixedUpdate()
        {
            movementHandler.ExternalFixedUpdate();
        }
        #endregion
    }
}
