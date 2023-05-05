using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.UIModule
{
    public class GameOverBtn : PanelChangerButton
    {
        #region Fields
        [Header("GameOver Btn Fields")]
        [SerializeField] private Enums.GameOverButtonType type;
        #endregion

        #region Core
        public override void Setup()
        {
            base.Setup();
        }
        public override void OnPressed()
        {
            GameManager gm = Core.Instance.GetManager(Utils.Enums.InitType.Afterýnit, Utils.Enums.ManagerType.GameManager) as GameManager;
            switch (type)
            {
                case Enums.GameOverButtonType.Reload:
                    gm.GameReload();
                    break;
                case Enums.GameOverButtonType.Restart:
                    gm.GameReload();
                    break;
            }
            base.OnPressed();
        }
        #endregion
    }
}
