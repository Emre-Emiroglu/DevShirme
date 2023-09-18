using DevShirme.DesignPatterns.Behaviorals;
using DevShirme.Interfaces;
using DevShirme.Managers.PoolManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        #region Fields
        [Header("Components")]
        [SerializeField] private WeaponData data;
        [SerializeField] private GameEvent onWeaponShoot;
        [SerializeField] private Transform muzzle;
        #endregion

        #region Getters
        public WeaponData WeaponData => data;
        #endregion

        #region Core
        public void Setup(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        public void Shoot()
        {
            Bullet bullet = (Bullet)((PoolManager)Core.Instance.GetManager(Utils.Enums.ManagerType.PoolManager)).GetObj("BulletPool", muzzle.position, muzzle.rotation, Vector3.one, null, true);
            bullet.Throw(data.BulletSpeed);

            onWeaponShoot?.Notify(data.ShootSound);
        }
        #endregion
    }
}
