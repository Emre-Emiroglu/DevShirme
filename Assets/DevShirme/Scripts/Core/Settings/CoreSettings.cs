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
        [Header("Managers Settings")]
        [SerializeField] private ScriptableObject[] managersSettings;
        #endregion

        #region Getters
        public ScriptableObject[] ManagersSettings => managersSettings;
        #endregion
    }
}
