using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "PoolSettings", menuName = "DevShirme/Settings/PoolSettings", order = 0)]
    public class PoolSettings : ScriptableObject
    {
        #region Fields
        [Header("Pool Settings")]
        [SerializeField] private Transform poolsParent;
        [SerializeField] private GameObject[] prefabs;
        [SerializeField] private string[] poolNames;
        [Range(0, 100)][SerializeField] private int initSize = 100;
        [Range(100, 1000)][SerializeField] private int maxSize = 500;
        #endregion

        #region Getters
        public Transform PoolsParent => poolsParent;
        public GameObject[] Prefabs => prefabs;
        public string[] PoolNames => poolNames;
        public int InitSize => initSize;
        public int MaxSize => maxSize;
        #endregion
    }
}
