using DevShirme.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    [Serializable]
    public class BulletModel : IBulletModel
    {
        #region Fields
        [Header("Bullet Model Settings")]
        [SerializeField] private float speed;
        #endregion

        #region Getters
        public float Speed => speed;
        #endregion
    }
}
