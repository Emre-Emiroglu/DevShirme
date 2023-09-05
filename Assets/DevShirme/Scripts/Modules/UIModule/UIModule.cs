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
        public UIModule(ScriptableObject _settings) : base(_settings)
        {
            uiSettings = _settings as UISettings;

            panels = Object.FindObjectsOfType<UIPanel>();

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
        public override void ExternalUpdate()
        {
        }
        public override void ExternalFixedUpdate()
        {
        }
        #endregion

        #region Subscriptions
        public override void SetSubscriptions(bool isSub)
        {
        }
        #endregion
    }
}
