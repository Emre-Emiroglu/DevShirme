using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class UIModel : IUIModel
    {
        private readonly UISettings uiSettings;

        public UISettings UISettings => uiSettings;

        public UIModel()
        {
            uiSettings = Resources.Load<UISettings>("Settings/UISettings");
        }
    }
}
