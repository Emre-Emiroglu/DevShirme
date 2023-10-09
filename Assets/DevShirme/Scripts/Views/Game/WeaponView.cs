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

        #region Getters
        public Transform Muzzle => muzzle;
        #endregion

        #region Core
        public void Shoot()
        {
            //TODO: FX etc.
        }
        #endregion
    }
}
