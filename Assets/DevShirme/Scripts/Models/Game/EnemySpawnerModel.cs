using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class EnemySpawnerModel : IEnemySpawnerModel
    {
        #region Fields
        private readonly EnemySpawnerSettings enemySpawnerSettings;
        #endregion

        #region Getters
        public EnemySpawnerSettings EnemySpawnerSettings => enemySpawnerSettings;
        #endregion

        #region Core
        public EnemySpawnerModel()
        {
            enemySpawnerSettings = Resources.Load<EnemySpawnerSettings>("Settings/EnemySpawnerSettings");
        }
        #endregion
    }
}
