using DevShirme.Interfaces.Game;
using DevShirme.Utils.Structs;
using UnityEngine;

namespace DevShirme.Views.PlayerAgent.AgentHandlers
{
    public class RotationHandler
    {
        #region Fields
        private readonly IPlayerModel playerModel;
        private readonly Structs.RotationData rotationData;
        #endregion

        #region Props
        public Structs.InputData InputData { get; set; }
        #endregion

        #region Core
        public RotationHandler(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
            rotationData = this.playerModel.RotationData;
        }
        #endregion

        #region Executes
        public void Reload(Transform obj, Rigidbody rb)
        {
            obj.rotation = Quaternion.identity;
            rb.angularVelocity = Vector3.zero;
        }
        private void Rotate(Transform obj)
        {
            Vector3 diff = new Vector3(InputData.RotationInput.x, 0f, InputData.RotationInput.y) - obj.position;

            Quaternion targetRot = Quaternion.LookRotation(diff, Vector3.up);

            obj.rotation = Quaternion.Lerp(obj.rotation, targetRot, Time.deltaTime * rotationData.RotationSpeed);
        }
        #endregion

        #region GameUpdates
        public void GameUpdate(Transform obj) => Rotate(obj);
        #endregion
    }
}
