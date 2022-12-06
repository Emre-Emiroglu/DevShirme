using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.EnemyModule
{
    public class EnemyController : DevShirmeController
    {
        #region Fields
        [Header("Enemy Controller Fields")]
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
        public override void GameStart()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GameStart();
            }
        }
        public override void Reload()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Reload();
            }
        }
        public override void GameOver()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GameOver();
            }
        }
        public override void GameSuccess()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GameSuccess();
            }
        }
        public override void GameFail()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GameFail();
            }
        }
        #endregion
    }
}
