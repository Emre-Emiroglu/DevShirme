using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IWeaponModel
    {
        public AudioClip ShootSound { get; }
        public float WeaponSpeedFactor { get; }
        public float FireRate { get; }
    }
}
