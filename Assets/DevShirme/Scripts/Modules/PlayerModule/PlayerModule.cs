using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.PlayerModule
{
    public class PlayerModule : Module
    {
        #region Fields
        [Header("Player Module Components")]
        private InputController inputController;
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();

            inputController = new InputController();
        }
        public override void Shutdown()
        {
            base.Shutdown();
        }
        protected override void setSubscriptions(bool isSub)
        {
            base.setSubscriptions(isSub);
        }
        #endregion
    }
}
