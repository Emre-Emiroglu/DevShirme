using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.PlayerModule
{
    public class PlayerController : DevShirmeController
    {
        #region Fields
        [Header("Player Controller Settings")]
        [SerializeField] private PlayerAgent agent;
        private bool isActive;
        private InputController inputController;
        private Vector2 inputDir;
        #endregion

        #region Core
        public override void Initialize()
        {
            agent?.Initialize(settings as PlayerSettings);

            inputController = new InputController();
            inputController.Behavior = InputBehavior.Clamped;
            inputController.ClampDistance = 80;
            inputController.Lerp = true;
            inputController.LerpSpeed = 0.1f;
            inputController.Sensitivity = 1f;
        }
        #endregion

        #region Updates
        private void MovementSetup()
        {
            if (isActive)
            {
                inputController.Update();
                inputDir.x = inputController.DeltaPos.x * Time.deltaTime;
                inputDir.y = inputController.DeltaPos.y * Time.deltaTime;

                agent.Movement(inputDir);
            }
        }
        private void Update()
        {
            if (((PlayerSettings)settings).MovementType == Enums.MovementType.Transform)
            {
                MovementSetup();
            }
        }
        private void FixedUpdate()
        {
            if (((PlayerSettings)settings).MovementType == Enums.MovementType.Rigidbody)
            {
                MovementSetup();
            }
        }
        #endregion
    }

}
