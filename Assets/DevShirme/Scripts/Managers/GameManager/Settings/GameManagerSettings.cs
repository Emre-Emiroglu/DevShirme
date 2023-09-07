using DevShirme.DesignPatterns.Behaviorals;
using DevShirme.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Managers.GameManager
{
    [CreateAssetMenu(fileName = "GameManagerSettings", menuName = "DevShirme/Settings/ManagerSettings/GameManagerSettings", order = 0)]
    public class GameManagerSettings : ScriptableObject
    {
        #region Fields
        [Header("Modules Settings")]
        [SerializeField] private ScriptableObject[] modulesSettings;
        [Header("Game Events")]
        [SerializeField] private GameEvent[] gameEvents;
        [Header("Game Settings")]
        [Range(30, 165)][SerializeField] private int targetFPS = 60;
        [SerializeField] private bool isCursorActive = false;
        [SerializeField] private CursorLockMode cursorLockMode;
        #endregion

        #region Getters
        public ScriptableObject[] ModulesSettings => modulesSettings;
        public GameEvent[] GameEvents => gameEvents;
        public int TargetFPS => targetFPS;
        public bool IsCursorActive => isCursorActive;
        public CursorLockMode CursorLockMode => cursorLockMode;
        #endregion
    }
}
