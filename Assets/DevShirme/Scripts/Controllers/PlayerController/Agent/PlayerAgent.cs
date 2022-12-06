using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public class PlayerAgent : MonoBehaviour, IGameCycle
    {
        #region Fields
        [Header("Components")]
        [SerializeField] private Rigidbody rb;
        [Header("Handlers")]
        private MovementHandler movementHandler;
        private RotationHandler rotationHandler;
        #endregion

        #region Core
        public void Initialize(PlayerSettings playerSettings)
        {
            movementHandler = new MovementHandler(playerSettings, transform, rb);
            rotationHandler = new RotationHandler(playerSettings, transform);
        }
        public void Initialize()
        {
        }
        public void GameStart()
        {
        }
        public void Reload()
        {
        }
        public void GameOver()
        {
        }
        public void GameSuccess()
        {
        }
        public void GameFail()
        {
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
