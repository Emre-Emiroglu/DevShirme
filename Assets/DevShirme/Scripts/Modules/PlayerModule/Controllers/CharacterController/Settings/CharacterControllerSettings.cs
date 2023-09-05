using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    [CreateAssetMenu(fileName = "ChracterControllerSettings", menuName = "DevShirme/Settings/ControllerSettings/ChracterControllerSettings", order = 1)]
    public class CharacterControllerSettings : ScriptableObject
    {
        #region Fields
        [Header("Handlers Datas")]
        [SerializeField] private Structs.MovementData movementData;
        [SerializeField] private Structs.RotationData rotationData;
        #endregion

        #region Getters
        public Structs.MovementData MovementData => movementData;
        public Structs.RotationData RotationData => rotationData;
        #endregion
    }
}
