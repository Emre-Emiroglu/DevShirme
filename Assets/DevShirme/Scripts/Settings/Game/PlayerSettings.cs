using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "DevShirme/Settings/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        #region Fields
        [Header("Player Settings")]
        [SerializeField] private Structs.MovementData movementData;
        [SerializeField] private Structs.RotationData rotationData;
        #endregion

        #region Getters
        public Structs.MovementData MovementData => movementData;
        public Structs.RotationData RotationData => rotationData;
        #endregion
    }
}
