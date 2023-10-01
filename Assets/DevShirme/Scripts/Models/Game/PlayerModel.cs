using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class PlayerModel : IPlayerModel
    {
        private readonly PlayerSettings playerSettings;

        public PlayerSettings PlayerSettings => playerSettings;

        public PlayerModel()
        {
            playerSettings = Resources.Load<PlayerSettings>("Settings/PlayerSettings");
        }
    }
}
