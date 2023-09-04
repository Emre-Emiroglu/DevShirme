using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Managers.DataManager
{
    [CreateAssetMenu(fileName = "DataManagerSettings", menuName = "DevShirme/Settings/ManagerSettings/DataManagerSettings", order = 0)]
    public class DataManagerSettings : ScriptableObject
    {
        #region Fields
        [Header("Included Modules")]
        [SerializeField] private Enums.DataManagerModuleType modules;
        [Header("Modules Settings")]
        [SerializeField] private ScriptableObject[] modulesSettings;
        [Header("Data Settings")]
        [SerializeField] private bool autoSave = false;
        [Tooltip("Its value is based on the minute")]
        [Range(1, 60)][SerializeField] private int autoSaveLength = 60;
        #endregion

        #region Getters
        public Enums.DataManagerModuleType Modules => modules;
        public ScriptableObject[] ModulesSettings => modulesSettings;
        public bool AutoSave => autoSave;
        public int AutoSaveLength => autoSaveLength;
        #endregion
    }
}
