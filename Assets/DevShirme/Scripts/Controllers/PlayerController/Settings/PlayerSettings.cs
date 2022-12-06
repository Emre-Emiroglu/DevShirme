using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevShirme.Utils;

namespace DevShirme.PlayerModule
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "DevShirme/Settings/Player Settings", order = 1)]
    public class PlayerSettings : DevSettings
    {
        #region Fields
        [SerializeField] private Enums.MovementType movementType;
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float rotationSpeed = 5f;
        #endregion

        #region Getters
        public Enums.MovementType MovementType => movementType;
        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;
        #endregion
    }
}
