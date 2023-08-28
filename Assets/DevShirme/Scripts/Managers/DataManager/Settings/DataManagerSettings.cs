using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    [CreateAssetMenu(fileName = "DataManagerSettings", menuName = "DevShirme/Settings/ManagerSettings/DataManagerSettings", order = 0)]
    public class DataManagerSettings : ScriptableObject
    {
        #region Fields
        [Header("Data Settings")]
        [SerializeField] private bool autoSave = false;
        [Tooltip("Its value is based on the minute")]
        [Range(1, 60)][SerializeField] private int autoSaveLength = 60;
        #endregion

        #region Getters
        public bool AutoSave => autoSave;
        public int AutoSaveLength => autoSaveLength;
        #endregion
    }
}
