using DevShirme.Interfaces;
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
        #endregion

        #region Core
        public override void PreRegister()
        {
        }
        public override void OnRegister()
        {
        }
        public override void OnRemove()
        {
        }
        #endregion

        #region Receivers
        private void onShoot() => WeaponView.Shoot();
        #endregion
    }
}