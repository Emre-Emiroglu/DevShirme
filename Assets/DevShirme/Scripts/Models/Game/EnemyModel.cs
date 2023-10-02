using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class EnemyModel : IEnemyModel
    {
        #region Fields
        private readonly EnemySettings enemySettings;
        #endregion

        #region Getters
        public EnemySettings EnemySettings => enemySettings;
        #endregion

        #region Core
        public EnemyModel()
        {
            enemySettings = Resources.Load<EnemySettings>("Settings/EnemySettings");
        }
        #endregion
    }
}
