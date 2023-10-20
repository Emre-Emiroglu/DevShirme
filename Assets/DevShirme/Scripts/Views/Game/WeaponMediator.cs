using DevShirme.Models;
using DevShirme.Utils;
using DevShirme.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Mediators
{
    public class WeaponMediator : MonoBehaviour, IDisposable
    {
        #region Injects
        private WeaponView view;
        private WeaponModel weaponModel;
        private PoolModel poolModel;
        private SignalBus signalBus;
        #endregion

        #region Core
        [Zenject.Inject]
        public void Construct(WeaponView view, WeaponModel weaponModel, PoolModel poolModel, SignalBus signalBus)
        {
            this.view = view;
            this.weaponModel = weaponModel;
            this.poolModel = poolModel;
            this.signalBus = signalBus;

            signalBus.Subscribe<Structs.OnWeaponCanShoot>(onWeaponCanShoot);
        }
        public void Dispose()
        {
            signalBus.Unsubscribe<Structs.OnWeaponCanShoot>(onWeaponCanShoot);
        }
        #endregion

        #region Receivers
        private void onWeaponCanShoot()
        {
            poolModel.GetPoolObject("Bullet", view.Muzzle.position, view.Muzzle.rotation, Vector3.one, null, true);

            signalBus.Fire(new Structs.OnPlaySound { AudioClip = weaponModel.ShootSound });

            view.Shoot();
        } 
        #endregion
    }
}
