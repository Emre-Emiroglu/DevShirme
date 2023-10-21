using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class EnemyView : PoolObjectView
    {
        #region Fields
        private Transform playerTransform;
        private float followSpeed;
        private float turnSpeed;
        #endregion

        #region Core
        public void Setup(Transform playerTransform, float followSpeed, float turnSpeed)
        {
            this.playerTransform = playerTransform;
            this.followSpeed = followSpeed;
            this.turnSpeed = turnSpeed;
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
                Follow(playerTransform, followSpeed, turnSpeed);
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
