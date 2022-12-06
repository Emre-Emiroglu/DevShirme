using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DevShirme.DataModule;

namespace DevShirme.Helpers
{
    public static class ScoreHandler
    {
        #region Fields
        public static Action<int> OnPlayerScoreChanged;
        private static int currentPlayerScore;
        #endregion

        #region Getters
        public static int CurrentPlayerScore => currentPlayerScore;
        #endregion

        #region Executes
        public static void SetCurrentScore(int amount, bool uiRefresh = true, bool save = true)
        {
            currentPlayerScore += amount;
            if (uiRefresh)
            {
                OnPlayerScoreChanged?.Invoke(currentPlayerScore);
            }
            if (save)
            {
                DataManager dm = DevShirmeCore.Instance.GetAManager(Utils.Enums.ManagerType.DataManager) as DataManager;
                dm.PlayerData.Coin += amount;
                dm.PlayerData.SaveData();
            }
        }
        public static void Reload()
        {
            currentPlayerScore = 0;
            OnPlayerScoreChanged?.Invoke(currentPlayerScore);
        }
        #endregion
    }
}
