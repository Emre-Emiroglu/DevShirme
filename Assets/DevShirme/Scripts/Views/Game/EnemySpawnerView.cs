using DevShirme.Models;
using DevShirme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Views
{
    public class EnemySpawnerView : MonoBehaviour, IDisposable, ITickable
    {
        #region Injects
        private EnemySpawnerModel enemySpawnerModel;
        private PoolModel poolModel;
        private SignalBus signalBus;
        #endregion

        #region Fields
        [Header("Components")]
        [SerializeField] private Transform playerTransform;
        private float radius;
        private bool useGizmo;
        private Color gizmoColor;
        private bool isGameStart = false;
        private float timer;
        private float duration;
        #endregion

        #region Core
        [Inject]
        public void Construct(EnemySpawnerModel enemySpawnerModel, PoolModel poolModel, SignalBus signalBus)
        {
            this.enemySpawnerModel = enemySpawnerModel;
            this.poolModel = poolModel;
            this.signalBus = signalBus;

            duration = this.enemySpawnerModel.Duration;

            radius = this.enemySpawnerModel.Radius;
            useGizmo = this.enemySpawnerModel.UseGizmo;
            gizmoColor = this.enemySpawnerModel.GizmoColor;

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

            timer = 0f;
        }
        #endregion

        #region Spawn
        private void SpawnByTimer()
        {
            timer += Time.deltaTime;
            if (timer > duration)
            {
                timer = 0f;
                SpawnEnemy();
            }
        }
        private void SpawnEnemy()
        {
            Vector3 randomPos = UnityEngine.Random.insideUnitSphere * enemySpawnerModel.Radius;
            randomPos.y = 0f;
            poolModel.GetPoolObject("Enemy", transform.position + randomPos, Quaternion.identity, Vector3.one, null, true);
        }
        #endregion

        #region Ticks
        public void Tick()
        {
            if (!isGameStart)
                return;

            transform.position = playerTransform.position;

            SpawnByTimer();
        }
        #endregion

        #region Gizmo
        private void OnDrawGizmosSelected()
        {
            if (useGizmo)
            {
                Gizmos.color = gizmoColor;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }
        #endregion
    }
}
