using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class PCInputController : InputController
    {
        #region Fields
        private readonly Structs.PCInputData data;
        private Vector2 inputValue;
        private bool isRunKeyPressed;
        #endregion

        #region Getters
        #endregion

        #region Core
        public PCInputController(ScriptableObject _settings) : base(_settings)
        {
            this.data = _icSettings.PCInputData;
        }
        protected override void inputUpdate()
        {
            switch (data.PCInputBehavior)
            {
                case Enums.PCInputBehavior.Raw:
                    inputValue = new Vector2(Input.GetAxis(data.HorizontalAxis), Input.GetAxis(data.VerticalAxis));
                    break;
                case Enums.PCInputBehavior.NonRaw:
                    inputValue = new Vector2(Input.GetAxisRaw(data.HorizontalAxis), Input.GetAxisRaw(data.VerticalAxis));
                    break;
            }

            isRunKeyPressed = Input.GetKey(data.RunKey);

            if (Input.GetKeyUp(data.JumpKey))
            {
                Notify(inputValue, Enums.NotificationType.Jump);
            }
            else if(isRunKeyPressed)
            {
                Notify(inputValue, Enums.NotificationType.Run);
            }
            else
            {
                Notify(inputValue, Enums.NotificationType.Walk);
            }
        }
        public override void ClearInputs()
        {
            inputValue = Vector2.zero;
            isRunKeyPressed = false;
        }
        #endregion

        #region Updates
        public override void ExternalUpdate()
        {
            base.ExternalUpdate();

            inputUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            base.ExternalFixedUpdate();
        }
        #endregion
    }
}
