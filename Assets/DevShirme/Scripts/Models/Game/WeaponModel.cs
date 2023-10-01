using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class WeaponModel : IWeaponModel
    {
        private readonly WeaponSettings weaponSettings;
        
        public WeaponSettings WeaponSettings => weaponSettings;

        public WeaponModel()
        {
            weaponSettings = Resources.Load<WeaponSettings>("Settings/WeaponSettings");
        }
    }
}
