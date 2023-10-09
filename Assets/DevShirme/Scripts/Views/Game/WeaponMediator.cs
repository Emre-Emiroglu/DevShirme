using DevShirme.Interfaces;
using DevShirme.Signals;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class WeaponMediator : Mediator
    {
        #region Injects
        [Inject] public WeaponView WeaponView { get; set; }
        [Inject] public IWeaponModel WeaponModel { get; set; }
        [Inject] public IPoolModel PoolModel { get; set; }
        [Inject] public GameSignal GameSignal { get; set; }
        [Inject] public PoolSignal PoolSignal { get; set; }
        [Inject] public AudioSignal AudioSignal { get; set; }
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
            GameSignal.OnWeaponCanShoot.AddListener(onWeaponCanShoot);
        }
        public override void OnRemove()
        {
            GameSignal.OnWeaponCanShoot.RemoveListener(onWeaponCanShoot);
        }
        #endregion

        #region Receivers
        private void onWeaponCanShoot()
        {
            PoolModel.GetPoolObject("Bullet", WeaponView.Muzzle.position, WeaponView.Muzzle.rotation, Vector3.one, null, true);

            //AudioSignal.OnPlaySound?.Dispatch(WeaponModel.WeaponSettings.ShootSound);

            WeaponView.Shoot();
        } 
        #endregion
    }
}
