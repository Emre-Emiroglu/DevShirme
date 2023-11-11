using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces.Game
{
    public interface IWeaponModel
    {
        public AudioClip ShootSound { get; }
        public float WeaponSpeedFactor { get; }
        public float FireRate { get; }
    }
}
