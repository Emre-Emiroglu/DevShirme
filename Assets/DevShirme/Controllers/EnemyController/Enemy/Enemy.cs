using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.EnemyModule
{
    public class Enemy : MonoBehaviour
    {
        #region Fields
        [Header("Enemy Components")]
        [SerializeField] private FowSensor fowSensor;
        #endregion

        #region Core
        public void Initialize()
        {
            fowSensor.Initialize();
            fowSensor.OnDetected += onDetected;
        }
        private void OnDestroy()
        {
            fowSensor.OnDetected -= onDetected;
        }
        #endregion

        #region Receviers
        private void onDetected(Transform target)
        {
        }
        #endregion

        #region Movement
        #endregion
    }
}
