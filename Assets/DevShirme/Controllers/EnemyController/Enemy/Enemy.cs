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
        }
        #endregion

        #region SensorExecutes
        public void StartSearch()
        {
            fowSensor.StartSensor();
        }
        public void StopSearch()
        {
            fowSensor.StopSensor();
        }
        #endregion

        #region Movement
        #endregion
    }
}
