using DevShirme.Interfaces;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class EnemyMediator : Mediator
    {
        #region Injects
        [Inject] public EnemyView EnemyView { get; set; }
        [Inject] public IEnemyModel EnemyModel { get; set; }
        [Inject] public IPlayerModel PlayerModel { get; set; }
        #endregion

        #region Fields
        private Transform playerTransform;
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
            playerTransform = PlayerModel.PlayerTransform;
        }
        public override void OnRemove()
        {
        }
        #endregion

        #region Updates
        private void Update()
        {
            if (EnemyView.InUse)
            {
                EnemyView.Follow(playerTransform, EnemyModel.EnemySettings.FollowSpeed, EnemyModel.EnemySettings.TurnSpeed);
            }
        }
        #endregion
    }
}
