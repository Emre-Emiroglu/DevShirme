using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.UIModule
{
    public class UIModule : Module
    {
        #region Fields
        [Header("UI Controller Fields")]
        [SerializeField] private List<UIPanel> panels;
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();

            transation(Enums.UIPanelType.MainMenuPanel);
        }
        protected override void setSubs(bool isSub)
        {
            base.setSubs(isSub);
        }
        #endregion

        #region PanelProcess
        private void transation(Enums.UIPanelType newPanel)
        {
            panels.ForEach(x => x.Hide());
            panels[((int)newPanel)].Show();
        }
        #endregion
    }
}
