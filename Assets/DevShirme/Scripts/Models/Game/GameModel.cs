using DevShirme.Interfaces;
using DevShirme.Settings;
using DevShirme.Utils;
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

        #region Props
        public Enums.GameState GameState { get; set; }
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
