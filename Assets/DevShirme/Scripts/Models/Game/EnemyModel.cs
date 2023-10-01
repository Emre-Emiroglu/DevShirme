using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class EnemyModel : IEnemyModel
    {
        private readonly EnemySettings enemySettings;

        public EnemySettings EnemySettings => enemySettings;

        public EnemyModel()
        {
            enemySettings = Resources.Load<EnemySettings>("Settings/EnemySettings");
        }
    }
}
