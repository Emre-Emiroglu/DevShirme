using DevShirme.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class EnemyView : PoolObjectView
    {
        #region Fields
        public Action OnDead { get; set; }
        #endregion

        #region Core
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
        public void Follow(Transform target, float followSpeed, float turnSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * followSpeed);

            Vector3 diff = target.position - transform.position;

            Quaternion lookRot = Quaternion.LookRotation(diff, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * turnSpeed);
        }
        #endregion

        #region Dead
        public void Dead()
        {
            OnDead?.Invoke();

            DeSpawn();
        }
        #endregion

        #region Physic
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
                Dead();
        }
        #endregion
    }
}
