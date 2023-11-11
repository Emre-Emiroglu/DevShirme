using DevShirme.Interfaces.Game;
using DevShirme.Utils.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models.Game
{
    [Serializable]
    public class GameModel : IGameModel
    {
        #region Fields
        [Header("Game Model Settings")]
        [Range(30, 165)][SerializeField] private int targetFPS = 60;
        [SerializeField] private bool isCursorActive = false;
        [SerializeField] private CursorLockMode cursorLockMode;
        #endregion

        #region Props
        public Enums.GameState GameState { get; set; }
        public int TargetFPS => targetFPS;
        public bool IsCursorActive => isCursorActive;
        public CursorLockMode CursorLockMode => cursorLockMode;
        #endregion
    }
}
