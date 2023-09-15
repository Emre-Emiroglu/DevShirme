using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.Modules.UIModule
{
    public class UIModule : Module
    {
        #region Fields
        private readonly UISettings uiSettings;
        private readonly UIPanel[] panels;
        #endregion

        #region Core
        public UIModule(UISettings uiSettings, UIPanel[] panels) : base()
        {
            this.uiSettings = uiSettings;
            this.panels = panels;

            transation(Enums.UIPanelType.MainMenuPanel);
        }
        #endregion

        #region PanelProcess
        private void transation(Enums.UIPanelType newPanel)
        {
            for (int i = 0; i < panels.Length; i++)
                panels[i].Hide();
            
            panels[((int)newPanel)].Show();
        }
        #endregion

        #region Updates
        public override void Tick()
        {
        }
        public override void FixedTick()
        {
        }
        public override void LateTick()
        {
        }
        #endregion
    }
}
