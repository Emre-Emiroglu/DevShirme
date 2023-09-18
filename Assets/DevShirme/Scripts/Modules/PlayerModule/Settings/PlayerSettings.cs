using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "DevShirme/Settings/ModuleSettings/PlayerSettings", order = 1)]
    public class PlayerSettings : ScriptableObject
    {
        #region Fields
        [Header("Controllers Settings")]
        [SerializeField] private ScriptableObject[] controllersSettings;
        #endregion

        #region Getters
        public ScriptableObject[] ControllersSettings => controllersSettings;
        #endregion
    }
}
