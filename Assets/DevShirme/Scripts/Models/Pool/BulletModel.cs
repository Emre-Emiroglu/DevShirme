using DevShirme.Interfaces.Pool;
using System;
using UnityEngine;

namespace DevShirme.Models.Pool
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
