using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public class PlayerAgent : MonoBehaviour
    {
        #region Fields
        [Header("Components")]
        private Rigidbody rb;
        [Header("Handlers")]
        private MovementHandler movementHandler;
        private RotationHandler rotationHandler;
        #endregion

        #region Core
        public void Initialize(PlayerSettings playerSettings)
        {
            rb = GetComponent<Rigidbody>();
            movementHandler = new MovementHandler(playerSettings, transform, rb);
            rotationHandler = new RotationHandler(playerSettings, transform);
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
