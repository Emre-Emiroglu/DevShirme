using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class BulletModel : IBulletModel
    {
        #region Fields
        private BulletSettings bulletSettings;
        #endregion

        #region Getters
        public BulletSettings BulletSettings => bulletSettings;
        #endregion

        #region Core
        public BulletModel()
        {
            bulletSettings = Resources.Load<BulletSettings>("Settings/BulletSettings");
        }
        #endregion
    }
}
