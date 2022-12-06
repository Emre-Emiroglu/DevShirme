using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.EnemyModule
{
    public class Enemy : MonoBehaviour, IGameCycle
    {
        #region Fields
        [Header("Enemy Components")]
        [SerializeField] private FowSensor fowSensor;
        #endregion

        #region Core
        public void Initialize()
        {
            fowSensor.Initialize();
        }
        public void GameStart()
        {
            fowSensor.OnDetected += onDetected;
        }
        public void Reload()
        {
        }
        public void GameOver()
        {
            fowSensor.OnDetected -= onDetected;
        }
        public void GameFail()
        {
        }
        public void GameSuccess()
        {
        }
        #endregion

        #region Receviers
        private void onDetected(Transform target)
        {
        }
        #endregion
    }
}
