using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    [CreateAssetMenu(fileName = "GameManagerSettings", menuName = "DevShirme/ManagerSettings/GameManagerSettings", order = 0)]
    public class GameManagerSettings : ScriptableObject
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
