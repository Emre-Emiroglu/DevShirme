using DevShirme.Interfaces;
using DevShirme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    [Serializable]
    public class InputModel : IInputModel
    {
        #region Fields
        [Header("Input Model Settings")]
        [SerializeField] private Structs.PCInputData pcInputData;
        [SerializeField] private Structs.MobileInputData mobileInputData;
        #endregion

        #region Getters
        public Structs.PCInputData PCInputData => pcInputData;
        public Structs.MobileInputData MobileInputData => mobileInputData;
        #endregion

        #region Core
        public void Initialize() { }
        #endregion
    }
}
