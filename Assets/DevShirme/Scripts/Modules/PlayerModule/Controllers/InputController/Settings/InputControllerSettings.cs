using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    [CreateAssetMenu(fileName = "InputControllerSettings", menuName = "DevShirme/Settings/ControllerSettings/InputControllerSettings", order = 1)]
    public class InputControllerSettings : ScriptableObject
    {
        #region Fields
        [Header("Input General Settings")]
        [SerializeField] private Enums.InputType inputType;
        [Header("Mobile Input Settings")]
        [SerializeField] private Structs.MobileInputData mobileInputData;
        [Header("PC Input Settings")]
        [SerializeField] private Structs.PCInputData pcInputData;
        #endregion

        #region Getters
        public Enums.InputType InputType => inputType;
        public Structs.MobileInputData MobileInputData => mobileInputData;
        public Structs.PCInputData PCInputData => pcInputData;
        #endregion
    }
}

