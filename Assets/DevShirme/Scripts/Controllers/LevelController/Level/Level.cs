using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.LevelModule
{
    [CreateAssetMenu(fileName = "Level", menuName = "DevShirme/Level", order = 1)]
    public class Level : ScriptableObject
    {
        #region Fields
        [Header("Level Settings")]
        [SerializeField] private LevelDesign design;
        #endregion

        #region Getters
        public LevelDesign LevelDesign => design;
        #endregion
    }
}
