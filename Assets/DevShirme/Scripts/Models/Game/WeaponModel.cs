using DevShirme.Interfaces.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models.Game
{
    [Serializable]
    public class WeaponModel : IWeaponModel
    {
        #region Fields
        [Header("Weapon Model Settings")]
        [SerializeField] private AudioClip shootSound;
        [SerializeField] private float weaponSpeedFactor;
        [SerializeField] private float fireRate;
        #endregion

        #region Getters
        public AudioClip ShootSound => shootSound;
        public float WeaponSpeedFactor => weaponSpeedFactor;
        public float FireRate => fireRate;
        #endregion
    }
}
