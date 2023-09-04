using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.Modules.UIModule
{
    public class UIModule : Module
    {
        #region Fields
        private readonly UIPanel[] panels;
        #endregion

        #region Core
        public UIModule(ScriptableObject _settings) : base(_settings)
        {
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
            base.ExternalUpdate();
        }
        public override void ExternalFixedUpdate()
        {
            base.ExternalFixedUpdate();
        }
        #endregion

        #region Subscriptions
        public override void SetSubscriptions(bool isSub)
        {
        }
        #endregion
    }
}
