using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class InputModel : IInputModel
    {
        #region Fields
        private readonly InputSettings inputSettings;
        #endregion

        #region Getters
        public InputSettings InputSettings => inputSettings;
        #endregion

        #region Core
        public InputModel()
        {
            inputSettings = Resources.Load<InputSettings>("Settings/InputSettings");
        }
        #endregion
    }
}
