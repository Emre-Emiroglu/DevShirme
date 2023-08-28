using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public class PlayerModule : Module
    {
        #region Fields
        private readonly PlayerSettings playerSettings;
        private readonly InputController inputController;
        #endregion

        #region Core
        public PlayerModule(ScriptableObject _settings) : base(_settings)
        {
            playerSettings = _settings as PlayerSettings;

            inputController = new InputController();
        }
        public override void SetSubscriptions(bool isSub)
        {
        }
        #endregion
    }
}
