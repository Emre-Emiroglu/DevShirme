using DevShirme.Interfaces.Game;
using DevShirme.Utils.Structs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models.Game
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
    }
}
