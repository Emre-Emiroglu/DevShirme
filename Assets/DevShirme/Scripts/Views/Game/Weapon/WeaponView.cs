using UnityEngine;
using Zenject;
using System;
using DevShirme.Models.Pool;
using DevShirme.Models.Game;
using DevShirme.Utils.Structs;
using DevShirme.Views.Bullet;
using DevShirme.Utils.Enums;

namespace DevShirme.Views.Weapon
{
    public class WeaponView : MonoBehaviour, IInitializable, IDisposable
    {
        #region Injects
        [Inject] private WeaponModel weaponModel;
        [Inject] private BulletModel bulletModel;
        [Inject] private PoolModel poolModel;
        [Inject] private SignalBus signalBus;
        #endregion

        #region Fields
        [Header("Components")]
        [SerializeField] private Transform muzzle;
        #endregion

        #region Core
        public void Initialize()
        {
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

            signalBus.Fire(new Structs.OnPlaySound { AudioSourceType = Enums.AudioSourceTypes.PlayerAudioSource,
                AudioClip = weaponModel.ShootSound });

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
