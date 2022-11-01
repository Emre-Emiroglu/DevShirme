using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.EnemyModule
{
    public class EnemyController : DevShirmeController
    {
        #region Fields
        [SerializeField] private List<Enemy> enemies;
        #endregion

        #region Core
        public override void Initialize()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Initialize();
            }
        }
        #endregion
    }
}
