using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "InputSettings", menuName = "DevShirme/Settings/InputSettings")]
    public class InputSettings : ScriptableObject
    {
        #region Fields
        [Header("Input Settings")]
        [SerializeField] private Structs.PCInputData pcInputData;
        [SerializeField] private Structs.MobileInputData mobileInputData;
        #endregion

        #region Getters
        public Structs.PCInputData PCInputData => pcInputData;
        public Structs.MobileInputData MobileInputData => mobileInputData;
        #endregion
    }
}
