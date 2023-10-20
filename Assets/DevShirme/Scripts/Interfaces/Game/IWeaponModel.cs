using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DevShirme.Interfaces
{
    public interface IWeaponModel: IInitializable
    {
        public AudioClip ShootSound { get; }
        public float WeaponSpeedFactor { get; }
        public float FireRate { get; }
    }
}
