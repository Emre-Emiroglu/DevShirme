using DevShirme.Models;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

namespace DevShirme.Views
{
    public class WeaponView : MonoBehaviour, IDisposable
    {
        #region Injects
        private WeaponModel weaponModel;
        private BulletModel bulletModel;
        private PoolModel poolModel;
        private SignalBus signalBus;
        #endregion

        #region Fields
        [Header("Components")]
        [SerializeField] private Transform muzzle;
        #endregion

        #region Core
        [Inject]
        public void Construct(WeaponModel weaponModel, BulletModel bulletModel, PoolModel poolModel, SignalBus signalBus)
        {
            this.weaponModel = weaponModel;
            this.bulletModel = bulletModel;
            this.poolModel = poolModel;
            this.signalBus = signalBus;

            signalBus.Subscribe<Structs.OnWeaponCanShoot>(OnWeaponCanShoot);
        }
        public void Dispose()
        {
            signalBus.TryUnsubscribe<Structs.OnWeaponCanShoot>(OnWeaponCanShoot);
        }
        #endregion

        #region Receivers
        private void OnWeaponCanShoot()
        {
            BulletView bulletView = poolModel.GetPoolObject("Bullet", muzzle.position, muzzle.rotation, Vector3.one, null, true) as BulletView;
            bulletView.Throw(bulletModel.Speed * weaponModel.WeaponSpeedFactor);

            signalBus.Fire(new Structs.OnPlaySound { AudioClip = weaponModel.ShootSound });

            Shoot();
        }
        #endregion

        #region Executes
        private void Shoot()
        {
            //TODO: FX etc.
        }
        #endregion
    }
}
