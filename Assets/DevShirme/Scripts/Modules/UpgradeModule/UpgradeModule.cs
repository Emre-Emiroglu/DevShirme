using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.UpgradeModule
{
    public class UpgradeModule : Module
    {
        #region Core
        public override void Initialize()
        {
            base.Initialize();
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
