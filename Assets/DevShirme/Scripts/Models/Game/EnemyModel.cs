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
        private EnemySettings enemySettings;
        #endregion

        #region Getters
        public EnemySettings EnemySettings => enemySettings;
        #endregion

        #region Core
        public void Initialize()
        {
            enemySettings = Resources.Load<EnemySettings>("Settings/EnemySettings");
        }
        #endregion
    }
}
