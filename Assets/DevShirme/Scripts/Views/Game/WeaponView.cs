using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Views
{
    public class WeaponView : View
    {
        #region Fields
        [Header("Components")]
        [SerializeField] private Transform muzzle;
        #endregion

        #region Core
        public void Shoot()
        {
            //Bullet bullet = (Bullet)((PoolManager)Core.Instance.GetManager(Utils.Enums.ManagerType.PoolManager)).GetObj("BulletPool", muzzle.position, muzzle.rotation, Vector3.one, null, true);
            //bullet.Throw(data.BulletSpeed);

            //onWeaponShoot?.Notify(data.ShootSound);
        }
        #endregion
    }
}
