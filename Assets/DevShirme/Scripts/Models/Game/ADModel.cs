using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class ADModel : IADModel
    {
        #region Fields
        private readonly ADSettings adSettings;
        #endregion

        #region Getters
        public ADSettings ADSettings => adSettings;
        #endregion

        #region Core
        public ADModel()
        {
            adSettings = Resources.Load<ADSettings>("Settings/ADSettings");
        }
        #endregion
    }
}
