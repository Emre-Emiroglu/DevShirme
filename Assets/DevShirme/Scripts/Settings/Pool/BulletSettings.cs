using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "BulletSettings", menuName = "DevShirme/Settings/BulletSettings", order = 0)]
    public class BulletSettings : ScriptableObject
    {
        #region Fields
        [Header("Bullet Settings")]
        [Range(0, 100)][SerializeField] private float speed = 10;
        #endregion

        #region Getters
        public float Speed => speed;
        #endregion
    }
}
