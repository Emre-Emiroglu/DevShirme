using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.UIModule
{
    [CreateAssetMenu(fileName = "UISettings", menuName = "DevShirme/Settings/ModuleSettings/UISettings", order = 1)]
    public class UISettings : ScriptableObject
    {
        #region Fields
        [Header("Included Controllers")]
        [SerializeField] private Enums.UIModuleControllerType controllers;
        [Header("Controllers Settings")]
        [SerializeField] private ScriptableObject[] controllersSettings;
        #endregion

        #region Getters
        public Enums.UIModuleControllerType Controllers => controllers;
        public ScriptableObject[] ControllersSettings => controllersSettings;
        #endregion
    }
}

