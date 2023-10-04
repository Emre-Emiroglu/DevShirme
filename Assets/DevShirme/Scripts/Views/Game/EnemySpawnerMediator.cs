using DevShirme.Interfaces;
using DevShirme.Settings;
using DevShirme.Signals;
using DevShirme.Utils;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class EnemySpawnerMediator : Mediator
    {
        #region Injects
        [Inject] public EnemySpawnerView EnemySpawnerView { get; set; }
        [Inject] public IEnemySpawnerModel EnemySpawnerModel { get; set; }
        [Inject] public IPoolModel PoolModel { get; set; }
        [Inject] public GameSignal GameSignal { get; set; }
        #endregion

        #region Fields
        private bool isGameStart = false;
        private float timer;
        private float duration;
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
            EnemySpawnerSettings settings = EnemySpawnerModel.EnemySpawnerSettings;

            duration = settings.Duration;

            EnemySpawnerView.Initialize(
                settings.Radius,
                settings.UseGizmo,
                settings.GizmoColor);

            GameSignal.OnChangeGameState.AddListener(onChangeGameState);
        }
        public override void OnRemove()
        {
            GameSignal.OnChangeGameState.RemoveListener(onChangeGameState);
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
            Vector3 randomPos = Random.insideUnitSphere * EnemySpawnerModel.EnemySpawnerSettings.Radius;
            randomPos.y = 0f;
            PoolModel.GetPoolObject("Enemy", EnemySpawnerView.transform.position + randomPos, Quaternion.identity, Vector3.one, null, true);
        }
        #endregion

        #region Updates
        private void Update()
        {
            if (!isGameStart)
                return;

            EnemySpawnerView.OnGameUpdate();

            spawnByTimer();
        }
        #endregion
    }
}
