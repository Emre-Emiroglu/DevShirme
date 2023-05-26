using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public class PlayerModule : Module
    {
        #region Fields
        [Header("Player Module Components")]
        [SerializeField] private PlayerAgent playerAgent;
        private InputController inputController;
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();

            inputController = new InputController();
            playerAgent.Initialize(settings as PlayerSettings);
        }
        public override void OnGameStart()
        {
        }
        public override void OnGameReload()
        {
        }
        public override void OnGameOver()
        {
        }
        public override void OnGameSuccess()
        {
        }
        public override void OnGameFailed()
        {
        }
        protected override void setSubs(bool isSub)
        {
            base.setSubs(isSub);
        }
        #endregion
    }
}
