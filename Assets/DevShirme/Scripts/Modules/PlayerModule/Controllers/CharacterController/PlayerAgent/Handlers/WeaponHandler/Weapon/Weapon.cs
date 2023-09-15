using DevShirme.Interfaces;
using DevShirme.Managers.AudioManager;
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
        [SerializeField] private Transform muzzle;
        [SerializeField] private AudioClip shootSound;
        [SerializeField] private float speed;
        [SerializeField] private ForceMode forceMode;
        #endregion

        #region Core
        public void Setup(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        public void Shoot()
        {
            ((AudioManager)Core.Instance.GetManager(Utils.Enums.ManagerType.AudioManager)).PlaySound(shootSound);
            Bullet bullet = (Bullet)((PoolManager)Core.Instance.GetManager(Utils.Enums.ManagerType.PoolManager)).GetObj("BulletPool", muzzle.position, muzzle.rotation, Vector3.one, null, true);
            bullet.Throw(speed, forceMode);
        }
        #endregion
    }
}
