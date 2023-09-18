using DevShirme.Modules.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Interfaces
{
    public interface IWeapon
    {
        public WeaponData WeaponData { get; }
        public void Setup(bool isActive);
        public void Shoot();
    }
}
