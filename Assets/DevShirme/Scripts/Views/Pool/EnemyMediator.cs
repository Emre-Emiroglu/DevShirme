using DevShirme.Models;
using DevShirme.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Mediators
{
    public class EnemyMediator : MonoBehaviour, ITickable, IDisposable
    {
        #region Fields
        private EnemyView enemyView;
        private EnemyModel enemyModel;
        private PlayerModel playerModel;
        private Transform playerTransform;
        #endregion

        #region Core
        [Zenject.Inject]
        public void Construct(EnemyView enemyView, EnemyModel enemyModel, PlayerModel playerModel)
        {
            this.enemyView = enemyView;
            this.enemyModel = enemyModel;
            this.playerModel = playerModel;

            playerTransform = this.playerModel.PlayerTransform;

            this.enemyView.OnDead += onDead;
        }
        public void Dispose()
        {
            this.enemyView.OnDead -= onDead;
        }
        #endregion

        #region Receivers
        private void onDead() { Dispose(); }
        #endregion

        #region Updates
        public void Tick()
        {
            if (enemyView.InUse)
            {
                enemyView.Follow(playerTransform, enemyModel.FollowSpeed, enemyModel.TurnSpeed);
            }
        }
        #endregion
    }
}
