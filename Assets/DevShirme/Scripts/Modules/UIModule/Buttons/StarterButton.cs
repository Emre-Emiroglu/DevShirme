using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.UIModule
{
    public class StarterButton : PanelChangerButton
    {
        #region Core
        public override void Setup()
        {
            base.Setup();
        }
        public override void OnPressed()
        {
            GameManager gm = Core.Instance.GetManager(Utils.Enums.InitType.Afterýnit, Utils.Enums.ManagerType.GameManager) as GameManager;
            gm.GameStart();
            base.OnPressed();
        }
        #endregion
    }
}
