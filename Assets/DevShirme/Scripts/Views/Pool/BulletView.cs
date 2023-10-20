using DevShirme.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Views
{
    public class BulletView : PoolObjectView
    {
        #region Injects
        private BulletModel bulletModel;
        private WeaponModel weaponModel;
        #endregion

        #region Fields
        private Rigidbody rb;
        private float totalSpeed;
        #endregion

        #region Core
        [Inject]
        public void Construct(BulletModel bulletModel, WeaponModel weaponModel)
        {
            totalSpeed = bulletModel.Speed * weaponModel.WeaponSpeedFactor;
        }
        public override void Initialize()
        {
            base.Initialize();

            totalSpeed = 20;

            rb = GetComponent<Rigidbody>();
        }
        public override void Spawn(Vector3 pos, Quaternion rot, Vector3 scale, Transform parent, bool useRotation = false, bool useScale = false, bool setParent = false)
        {
            base.Spawn(pos, rot, scale, parent, useRotation, useScale, setParent);

            Throw(totalSpeed);
        }
        public override void DeSpawn()
        {
            base.DeSpawn();

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        #endregion

        #region Throw
        public void Throw(float speed) => rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        #endregion

        #region Physic
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
                DeSpawn();
        }
        #endregion
    }
}
