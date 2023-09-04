using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "DevShirme/Settings/ModuleSettings/PlayerSettings", order = 1)]
    public class PlayerSettings : ScriptableObject
    {
        #region Fields
        [Header("Included Controllers")]
        [SerializeField] private Enums.PlayerModuleControllerType controllers;
        [Header("Controllers Settings")]
        [SerializeField] private ScriptableObject[] controllersSettings;
        #endregion

        #region Getters
        public Enums.PlayerModuleControllerType Controllers => controllers;
        public ScriptableObject[] ControllersSettings => controllersSettings;
        #endregion
    }
}
