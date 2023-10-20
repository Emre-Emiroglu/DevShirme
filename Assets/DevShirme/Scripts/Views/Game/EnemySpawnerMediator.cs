using DevShirme.Models;
using DevShirme.Utils;
using DevShirme.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Mediators
{
    public class EnemySpawnerMediator : MonoBehaviour, IDisposable, ITickable
    {
        #region Fields
        private EnemySpawnerView view;
        private EnemySpawnerModel enemySpawnerModel;
        private PoolModel poolModel;
        private SignalBus signalBus;
        private bool isGameStart = false;
        private float timer;
        private float duration;
        #endregion

        #region Core
        [Inject]
        public void Construct(EnemySpawnerView view, EnemySpawnerModel enemySpawnerModel, PoolModel poolModel, SignalBus signalBus)
        {
            this.view = view;
            this.enemySpawnerModel = enemySpawnerModel;
            this.poolModel = poolModel;
            this.signalBus = signalBus;

            duration = this.enemySpawnerModel.Duration;

            view.Initialize(
                this.enemySpawnerModel.Radius,
                this.enemySpawnerModel.UseGizmo,
                this.enemySpawnerModel.GizmoColor);

            signalBus.Subscribe<Structs.OnChangeGameState>(x => onChangeGameState(x.NewGameState));
        }
        public void Dispose()
        {
            signalBus.Unsubscribe<Structs.OnChangeGameState>(x => onChangeGameState(x.NewGameState));
        }
        #endregion

        #region Receivers
        private void onChangeGameState(Enums.GameState gameState)
        {
            isGameStart = gameState == Enums.GameState.Start;

            timer = 0f;
        }
        #endregion

        #region Spawn
        private void spawnByTimer()
        {
            timer += Time.deltaTime;
            if (timer > duration)
            {
                timer = 0f;
                spawnEnemy();
            }
        }
        private void spawnEnemy()
        {
            Vector3 randomPos = UnityEngine.Random.insideUnitSphere * enemySpawnerModel.Radius;
            randomPos.y = 0f;
            poolModel.GetPoolObject("Enemy", view.transform.position + randomPos, Quaternion.identity, Vector3.one, null, true);
        }
        #endregion

        #region Ticks
        public void Tick()
        {
            if (!isGameStart)
                return;

            view.OnGameUpdate();

            spawnByTimer();
        }
        #endregion
    }
}
