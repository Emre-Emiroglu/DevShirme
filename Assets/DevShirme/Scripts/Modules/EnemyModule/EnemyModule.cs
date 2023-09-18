using DevShirme.Interfaces;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.EnemyModule
{
    public class EnemyModule : Module
    {
        #region Fields
        private readonly EnemySettings enemySettings;
        private readonly SpawnController spawnController;
        private readonly Transform playerTransform;
        private readonly List<IEnemy> enemies;
        private bool isActive;
        #endregion

        #region Core
        public EnemyModule(EnemySettings enemySettings, SpawnController spawnController, Transform playerTransform) : base()
        {
            this.enemySettings = enemySettings;
            this.spawnController = spawnController;
            this.playerTransform = playerTransform;

            this.spawnController.OnSpawn = onEnemySpawn;

            enemies = new List<IEnemy>();
        }
        #endregion

        #region Observer
        public override void OnNotify(object value, Enums.NotificationType notificationType)
        {
            isActive = notificationType == Enums.NotificationType.GameStart;

            if (notificationType == Enums.NotificationType.GameReload)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Dead();
                }
            }
        }
        #endregion

        #region Receivers
        private void onEnemySpawn(IPoolObject poolObject)
        {
            IEnemy enemy = poolObject as IEnemy;
            if (!enemies.Contains(enemy))
            {
                enemies.Add(enemy);
                enemy.OnDead = onEnemyDead;
            }
        }
        private void onEnemyDead(IEnemy enemy)
        {
            if (enemies.Contains(enemy))
                enemies.Remove(enemy);
        }
        #endregion

        #region Updates
        public override void Tick()
        {
            if (!isActive)
                return;

            spawnController?.Tick();

            for (int i = 0; i < enemies.Count; i++)
                enemies[i].Follow(playerTransform, enemySettings.FollowSpeed, enemySettings.TurnSpeed);
        }
        public override void FixedTick()
        {
            if (!isActive)
                return;

            spawnController?.FixedTick();
        }
        public override void LateTick()
        {
            if (!isActive)
                return;

            spawnController?.LateTick();
        }
        #endregion
    }
}
