using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Core
{
    public class DevShirmeCore : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private List<DevShirmeManager> managers;
        #endregion

        #region Initializes
        private void Awake()
        {
            for (int i = 0; i < managers.Count; i++)
            {
                managers[i].Initialize();
            }
        }
        #endregion

    }
}
