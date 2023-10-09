using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "DevShirme/Settings/GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        #region Fields
        [Header("Game Settings")]
        [Range(30, 165)][SerializeField] private int targetFPS = 60;
        [SerializeField] private bool isCursorActive = false;
        [SerializeField] private CursorLockMode cursorLockMode;
        #endregion

        #region Getters
        public int TargetFPS => targetFPS;
        public bool IsCursorActive => isCursorActive;
        public CursorLockMode CursorLockMode => cursorLockMode;
        #endregion
    }
}
