using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class GameModel : IGameModel
    {
        #region Fields
        private readonly GameSettings gameSettings;
        #endregion

        #region Getters
        public GameSettings GameSettings => gameSettings;
        #endregion

        #region Core
        public GameModel()
        {
            gameSettings = Resources.Load<GameSettings>("Settings/GameSettings");
        }
        #endregion
    }
}
