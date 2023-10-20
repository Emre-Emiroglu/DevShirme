using DevShirme.Models;
using DevShirme.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Mediators
{
    public class BulletMediator : MonoBehaviour
    {
        #region Fields
        private BulletView bulletView;
        private BulletModel bulletModel;
        private WeaponModel weaponModel;
        private float totalSpeed;
        #endregion

        #region Core
        [Zenject.Inject]
        public void Construct(BulletView bulletView, BulletModel bulletModel, WeaponModel weaponModel)
        {
            totalSpeed = bulletModel.Speed * weaponModel.WeaponSpeedFactor;

            bulletView.TotalSpeed = totalSpeed;
        }
        public void Dispose()
        {
        }
        #endregion
    }
}
