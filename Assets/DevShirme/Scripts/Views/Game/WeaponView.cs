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
        private PoolModel poolModel;
        private SignalBus signalBus;
        #endregion

        #region Fields
        [Header("Components")]
        [SerializeField] private Transform muzzle;
        #endregion

        #region Core
        [Inject]
        public void Construct(WeaponModel weaponModel, PoolModel poolModel, SignalBus signalBus)
        {
            this.weaponModel = weaponModel;
            this.poolModel = poolModel;
            this.signalBus = signalBus;

            signalBus.Subscribe<Structs.OnWeaponCanShoot>(OnWeaponCanShoot);
        }
        public void Dispose()
        {
            signalBus.Unsubscribe<Structs.OnWeaponCanShoot>(OnWeaponCanShoot);
        }
        #endregion

        #region Receivers
        private void OnWeaponCanShoot()
        {
            poolModel.GetPoolObject("Bullet", muzzle.position, muzzle.rotation, Vector3.one, null, true);

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
