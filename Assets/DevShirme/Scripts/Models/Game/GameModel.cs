using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class GameModel : IGameModel
    {
        private readonly GameSettings gameSettings;

        public GameSettings GameSettings => gameSettings;

        public GameModel()
        {
            gameSettings = Resources.Load<GameSettings>("Settings/GameSettings");
        }
    }
}
