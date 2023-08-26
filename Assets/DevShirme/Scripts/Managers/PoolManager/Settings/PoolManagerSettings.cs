using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    [CreateAssetMenu(fileName ="PoolManagerSettings", menuName ="DevShirme/ManagerSettings/PoolManagerSettings", order = 0)]
    public class PoolManagerSettings : ScriptableObject
    {
        #region Fields
        [Header("Pool Settings")]
        [SerializeField] private GameObject[] prefabs;
        [SerializeField] private string[] poolNames;
        [Range(0, 100)][SerializeField] private int initSize = 100;
        [Range(100, 1000)][SerializeField] private int maxSize = 500;
        #endregion

        #region Getters
        public GameObject[] Prefabs => prefabs;
        public string[] PoolNames => poolNames;
        public int InitSize => initSize;
        public int MaxSize => maxSize;
        #endregion
    }
}