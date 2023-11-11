using DevShirme.Models.Game;
using DevShirme.Models.Pool;
using DevShirme.Utils.Enums;
using DevShirme.Utils.Structs;
using DevShirme.Views.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Views.EnemySpawner
{
    public class EnemySpawnerView : MonoBehaviour, IDisposable, ITickable
    {
        #region Injects
        private EnemySpawnerModel enemySpawnerModel;
        private EnemyModel enemyModel;
        private PoolModel poolModel;
        private SignalBus signalBus;
        #endregion

        #region Fields
        [Header("Components")]
        [SerializeField] private Transform playerTransform;
        private bool isGameStart = false;
        private float timer;
        private readonly List<EnemyView> enemyViews = new List<EnemyView>();
        #endregion

        #region Core
        [Inject]
        public void Construct(EnemySpawnerModel enemySpawnerModel, EnemyModel enemyModel, PoolModel poolModel, SignalBus signalBus)
        {
            this.enemySpawnerModel = enemySpawnerModel;
            this.enemyModel = enemyModel;
            this.poolModel = poolModel;
            this.signalBus = signalBus;

            this.signalBus.Subscribe<Structs.OnChangeGameState>(x => OnChangeGameState(x.NewGameState));
        }
        public void Dispose()
        {
            signalBus.TryUnsubscribe<Structs.OnChangeGameState>(x => OnChangeGameState(x.NewGameState));
        }
        #endregion

        #region Receivers
        private void OnChangeGameState(Enums.GameState gameState)
        {
            isGameStart = gameState == Enums.GameState.Start;

            enemyViews.Clear();

            timer = 0f;
        }
        #endregion

        #region Spawn
        private void SpawnByTimer()
        {
            timer += Time.deltaTime;
            if (timer > enemySpawnerModel.Duration)
            {
                timer = 0f;
                SpawnEnemy();
            }
        }
        private void SpawnEnemy()
        {
            Vector3 randomPos = UnityEngine.Random.insideUnitSphere * enemySpawnerModel.Radius;
            randomPos.y = 0f;
            EnemyView enemyView = poolModel.GetPoolObject("Enemy", transform.position + randomPos, Quaternion.identity, Vector3.one, null, true) as EnemyView;
            enemyView.Setup(playerTransform, enemyModel.FollowSpeed, enemyModel.TurnSpeed);
            if (!enemyViews.Contains(enemyView))
                enemyViews.Add(enemyView);
        }
        #endregion

        #region Ticks
        public void Tick()
        {
            if (!isGameStart)
                return;

            for (int i = 0; i < enemyViews.Count; i++)
                enemyViews[i].Tick();

            transform.position = playerTransform.position;

            SpawnByTimer();
        }
        #endregion

        #region Gizmo
        private void OnDrawGizmosSelected()
        {
            if (enemySpawnerModel != null && enemySpawnerModel.UseGizmo)
            {
                Gizmos.color = enemySpawnerModel.GizmoColor;
                Gizmos.DrawWireSphere(transform.position, enemySpawnerModel.Radius);
            }
        }
        #endregion
    }
}
