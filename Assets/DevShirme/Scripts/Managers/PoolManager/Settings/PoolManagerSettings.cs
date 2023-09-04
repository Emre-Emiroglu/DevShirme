using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Managers.PoolManager
{
    [CreateAssetMenu(fileName ="PoolManagerSettings", menuName ="DevShirme/Settings/ManagerSettings/PoolManagerSettings", order = 0)]
    public class PoolManagerSettings : ScriptableObject
    {
        #region Fields
        [Header("Included Modules")]
        [SerializeField] private Enums.PoolManagerModuleType modules;
        [Header("Modules Settings")]
        [SerializeField] private ScriptableObject[] modulesSettings;
        [Header("Pool Settings")]
        [SerializeField] private GameObject[] prefabs;
        [SerializeField] private string[] poolNames;
        [Range(0, 100)][SerializeField] private int initSize = 100;
        [Range(100, 1000)][SerializeField] private int maxSize = 500;
        #endregion

        #region Getters
        public Enums.PoolManagerModuleType Modules => modules;
        public ScriptableObject[] ModulesSettings => modulesSettings;
        public GameObject[] Prefabs => prefabs;
        public string[] PoolNames => poolNames;
        public int InitSize => initSize;
        public int MaxSize => maxSize;
        #endregion
    }
}
