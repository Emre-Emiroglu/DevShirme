using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class WeaponModel : IWeaponModel
    {
        #region Fields
        private readonly WeaponSettings weaponSettings;
        #endregion

        #region Getters
        public WeaponSettings WeaponSettings => weaponSettings;
        #endregion

        #region Core
        public WeaponModel()
        {
            weaponSettings = Resources.Load<WeaponSettings>("Settings/WeaponSettings");
        }
        #endregion
    }
}
