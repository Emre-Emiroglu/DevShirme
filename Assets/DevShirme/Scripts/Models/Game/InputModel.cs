using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class InputModel : IInputModel
    {
        private readonly InputSettings inputSettings;

        public InputSettings InputSettings => inputSettings;

        public InputModel()
        {
            inputSettings = Resources.Load<InputSettings>("Settings/InputSettings");
        }
    }
}
