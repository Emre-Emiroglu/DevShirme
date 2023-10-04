using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class UIModel : IUIModel
    {
        #region Fields
        private UISettings uiSettings;
        #endregion

        #region Getters
        public UISettings UISettings => uiSettings;
        #endregion

        #region Core
        public void Initialize()
        {
            uiSettings = Resources.Load<UISettings>("Settings/UISettings");
        }
        #endregion
    }
}
