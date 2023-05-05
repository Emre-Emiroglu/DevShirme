using DevShirme.Helpers;
using DevShirme.Interfaces;
using DevShirme.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public class GameManager : Manager
    {
        #region Actions
        public static event Action OnGameStart;
        public static event Action OnGameReload;
        public static event Action OnGameOver;
        public static event Action OnGameSuccess;
        public static event Action OnGameFailed;
        public static Action<int> OnCoinChanged;
        public static Action<Enums.UIPanelType> OnPanelChangerButtonPressed;
        public static Action<int> OnLevelCreated;
        #endregion

        #region Fields
        [Header("Game Manager Components")]
        [SerializeField] private List<Module> modules;
        #endregion

        #region Core
        public override void Initialize()
        {
            for (int i = 0; i < modules.Count; i++)
            {
                modules[i].Initialize();
            }
        }
        public void GameStart() => OnGameStart?.Invoke();
        public void GameReload() => OnGameReload?.Invoke();
        public void GameOver() => OnGameOver?.Invoke();
        public void GameSuccess() => OnGameSuccess?.Invoke();
        public void GameFailed() => OnGameFailed?.Invoke();
        #endregion
    }
}
