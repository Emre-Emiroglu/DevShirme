using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public class PlayerAgent : MonoBehaviour
    {
        #region Fields
        [Header("Handlers")]
        [SerializeField] private MovementHandler movementHandler;
        [SerializeField] private RotationHandler rotationHandler;
        [Header("Components")]
        [SerializeField] private Rigidbody rb;
        private PlayerSettings playerSettings;
        #endregion

        #region Core
        public void Initialize(PlayerSettings playerSettings)
        {
            this.playerSettings = playerSettings;
            movementHandler.Initialize(this.playerSettings);
            rotationHandler.Initialize(this.playerSettings);
        }
        #endregion

        #region Handlers
        public void Movement(Vector2 input)
        {
            movementHandler.Execute(input);
        }
        public void Rotation(Vector2 input)
        {
            rotationHandler.Execute(input);
        }
        #endregion
    }

}
