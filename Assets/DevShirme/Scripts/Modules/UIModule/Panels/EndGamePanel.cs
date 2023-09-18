using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.UIModule
{
    public class EndGamePanel : UIPanel
    {
        #region Fields
        [SerializeField] private GameEventButton gameEventButton;
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();

            gameEventButton.Setup();
        }
        public override void Show()
        {
            base.Show();
        }
        public override void Hide()
        {
            base.Hide();
        }
        #endregion
    }
}
