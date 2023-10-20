using DevShirme.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using Zenject;
using Zenject.SpaceFighter;

namespace DevShirme.Views
{
    public class EnemyView : PoolObjectView, ITickable
    {
        #region Injects
        private EnemyModel enemyModel;
        private PlayerModel playerModel;
        #endregion

        #region Fields
        private Transform playerTransform;
        #endregion

        #region Core
        [Inject]
        public void Construct(EnemyModel enemyModel, PlayerModel playerModel)
        {
            this.enemyModel = enemyModel;
            this.playerModel = playerModel;

            playerTransform = this.playerModel.PlayerTransform;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Spawn(Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false)
        {
            base.Spawn(pos, rot, scale, parent, useRotation, useScale, setParent);
        }
        public override void DeSpawn()
        {
            base.DeSpawn();
        }
        #endregion

        #region Follow
        private void Follow(Transform target, float followSpeed, float turnSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * followSpeed);

            Vector3 diff = target.position - transform.position;

            Quaternion lookRot = Quaternion.LookRotation(diff, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * turnSpeed);
        }
        #endregion

        #region Ticks
        public void Tick()
        {
            if (InUse)
                Follow(playerTransform, enemyModel.FollowSpeed, enemyModel.TurnSpeed);
        }
        #endregion

        #region Physic
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
                DeSpawn();
        }
        #endregion
    }
}
