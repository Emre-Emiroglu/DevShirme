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
        protected override void setSubs(bool isSub)
        {
            base.setSubs(isSub);
        }
        #endregion
    }
}
