using DevShirme.Interfaces.Game;
using DevShirme.Utils.Enums;
using DevShirme.Utils.Structs;
using UnityEngine;

namespace DevShirme.Views.PlayerAgent.AgentHandlers
{
    public class MovementHandler
    {
        #region Fields
        private readonly IPlayerModel playerModel;
        private readonly Structs.MovementData movementData;
        #endregion

        #region Props
        public Structs.InputData InputData { get; set; }
        #endregion

        #region Core
        public MovementHandler(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
            movementData = this.playerModel.MovementData;
        }
        #endregion

        #region Executes
        public void Reload(Transform obj, Rigidbody rb)
        {
            obj.position = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
        private Vector3 GetAcceleration()
        {
            float speed = InputData.IsRunKeyPressed ? movementData.RunSpeed : movementData.WalkSpeed;
            Vector3 input = new Vector3(InputData.MovementInput.x, 0f, InputData.MovementInput.y);
            Vector3 acc = speed * input;

            return acc;
        }
        private void TransformMovement(Transform obj)
        {
            obj.position += GetAcceleration() * Time.deltaTime;
        }
        private void RigidbodyMovement(Rigidbody rb)
        {
            rb.velocity += GetAcceleration() * Time.fixedDeltaTime;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, InputData.IsRunKeyPressed ? movementData.RunSpeed : movementData.WalkSpeed);
        }
        #endregion

        #region GameUpdates
        public void GameUpdate(Transform obj)
        {
            if (movementData.MovementType == Enums.MovementType.Transform)
                TransformMovement(obj);
        }
        public void GameFixedUpdate(Rigidbody rb)
        {
            if (movementData.MovementType == Enums.MovementType.Rigidbody)
                RigidbodyMovement(rb);
        }
        #endregion
    }
}
