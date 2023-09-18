using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Modules.PlayerModule
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "DevShirme/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        #region Fields
        [Header("Weapon Settings")]
        [SerializeField] private AudioClip shootSound;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float fireRate;
        #endregion

        #region Getters
        public AudioClip ShootSound => shootSound;
        public float BulletSpeed => bulletSpeed;
        public float FireRate => fireRate;
        #endregion
    }
}
