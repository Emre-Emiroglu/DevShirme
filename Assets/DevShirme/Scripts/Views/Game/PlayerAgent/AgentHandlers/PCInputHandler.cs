using DevShirme.Interfaces.Game;
using DevShirme.Utils.Enums;
using DevShirme.Utils.Structs;
using UnityEngine;

namespace DevShirme.Views.PlayerAgent.AgentHandlers
{
    public class PCInputHandler
    {
        #region Fields
        private readonly IInputModel inputModel;
        private readonly Structs.PCInputData pcInputData;
        private Structs.InputData inputData;
        #endregion

        #region Getters
        public Structs.InputData InputData => inputData;
        #endregion

        #region Core
        public PCInputHandler(IInputModel inputModel)
        {
            this.inputModel = inputModel;
            pcInputData = this.inputModel.PCInputData;
        }
        #endregion

        #region Executes
        public void Reload()
        {
            inputData.MovementInput = Vector2.zero;
            inputData.RotationInput = Vector2.zero;
            inputData.MovementState = Enums.MovementState.Walk;
            inputData.LeftClick = false;
            inputData.IsRunKeyPressed = false;
        }
        private void PcInput()
        {
            switch (pcInputData.PCInputBehavior)
            {
                case Enums.PCInputBehavior.Raw:
                    inputData.MovementInput = new Vector2(Input.GetAxis(pcInputData.HorizontalAxis), Input.GetAxis(pcInputData.VerticalAxis));
                    break;
                case Enums.PCInputBehavior.NonRaw:
                    inputData.MovementInput = new Vector2(Input.GetAxisRaw(pcInputData.HorizontalAxis), Input.GetAxisRaw(pcInputData.VerticalAxis));
                    break;
            }

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
            inputData.RotationInput = new Vector2(mouseWorldPos.x, mouseWorldPos.z);

            inputData.IsRunKeyPressed = Input.GetKey(pcInputData.RunKey);

            inputData.MovementState = InputData.IsRunKeyPressed ? Enums.MovementState.Run : Enums.MovementState.Walk;

            inputData.LeftClick = Input.GetMouseButton(0);
        }
        #endregion

        #region GameUpdates
        public void GameUpdate() => PcInput();
        #endregion
    }
}
