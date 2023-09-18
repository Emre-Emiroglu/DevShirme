using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;
using DevShirme.Interfaces;

namespace DevShirme.Modules.UIModule
{
    public class UIModule : Module
    {
        #region Fields
        private readonly UISettings uiSettings;
        private readonly IPanel[] panels;
        #endregion

        #region Core
        public UIModule(UISettings uiSettings, IPanel[] panels) : base()
        {
            this.uiSettings = uiSettings;
            this.panels = panels;

            for (int i = 0; i < panels.Length; i++)
                panels[i].Initialize();

            transation(Enums.UIPanelType.MainMenuPanel);
        }
        #endregion

        #region Observer
        public override void OnNotify(object value, Enums.NotificationType notificationType)
        {
            switch (notificationType)
            {
                case Enums.NotificationType.GameStart:
                    transation(Enums.UIPanelType.InGamePanel);
                    break;
                case Enums.NotificationType.GameOver:
                    transation(Enums.UIPanelType.EndGamePanel);
                    break;
                case Enums.NotificationType.GameReload:
                    transation(Enums.UIPanelType.MainMenuPanel);
                    break;
            }
        }
        #endregion

        #region PanelProcess
        private void transation(Enums.UIPanelType newPanel)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                bool isActive = panels[i].PanelType == newPanel;
                if (isActive)
                    panels[i].Show();
                else
                    panels[i].Hide();
            }
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
