using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    [CreateAssetMenu(fileName ="CoreSettings", menuName ="DevShirme/Settings/CoreSettings")]
    public class CoreSettings : ScriptableObject
    {
        #region Fields
        [Header("Included Managers")]
        [SerializeField] private Enums.ManagerType managers;
        [Header("Managers Settings")]
        [SerializeField] private ScriptableObject[] managersSettings;
        #endregion

        #region Getters
        public Enums.ManagerType Managers => managers;
        public ScriptableObject[] ManagersSettings => managersSettings;
        #endregion
    }
}
