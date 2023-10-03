using DevShirme.Interfaces;
using DevShirme.Views;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class BulletMediator : Mediator
    {
        #region Injects
        [Inject] public BulletView BulletView { get; set; }
        [Inject] public IBulletModel BulletModel { get; set; }
        [Inject] public IWeaponModel WeaponModel { get; set; }
        #endregion

        #region Fields
        private float totalSpeed;
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
            totalSpeed = BulletModel.BulletSettings.Speed * WeaponModel.WeaponSettings.WeaponSpeedFactor;

            throwBullet();
        }
        public override void OnRemove()
        {
        }
        #endregion

        #region Executes
        private void throwBullet()=> BulletView.Throw(totalSpeed);
        #endregion
    }
}
